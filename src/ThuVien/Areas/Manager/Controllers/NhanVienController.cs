using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    //[Authorize]
    [Authorize(Policy = "Admin")]
    public class NhanVienController : Controller
    {
        private readonly INhanVienService nhanVienService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public NhanVienController(INhanVienService nhanVienService, UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            this.nhanVienService = nhanVienService;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var nhanViens = nhanVienService.GetNhanViens(sortOrder, searchString, pageIndex, pageSize, out count);
            var nhanVienNew = new NhanVienDTO();

            var test = nhanViens.ToList();

            foreach (var nhanVien in test)
            {
                var user = await userManager.FindByIdAsync(nhanVien.Id.ToString());
                if (user == null)
                {
                    ViewBag.ErrorMessage = $"User with ID= {nhanVien.Id.ToString()} not found.";
                }

                var currentUserClaims = await userManager.GetClaimsAsync(user);

                foreach (Claim claim in ClaimsStore.AllClaims.Where(c => c.Type != "Role"))
                {
                    var userClaim = new UserClaim
                    {
                        ClaimType = claim.Type
                    };

                    if (currentUserClaims.Any(c => c.Type == claim.Type))
                    {
                        userClaim.IsSelected = true;
                    }
                    nhanVien.UserClaims.Add(userClaim);
                }

                if (currentUserClaims.Any(c => c.Type == "Role" && c.Value == "Librarian"))
                {
                    nhanVien.Role = Role.Librarian;
                    nhanVien.UserClaims.RemoveRange(3, 2);
                }
                else
                {
                    if (currentUserClaims.Any(c => c.Type == "Role" && c.Value == "Admin") )
                    {
                        nhanVien.Role = Role.Admin;
                    }
                }
            }

            var nhanVienVM = new NhanVienIndexVm()
            {
                NhanViens = new PaginatedList<NhanVienDTO>(test, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                nhanVien = nhanVienNew
            };
            //Capture TempData và gán giá trị để truyền qua View
            ViewBag.NhanVien = Convert.ToInt32(TempData["NhanVien"]);
            return View(nhanVienVM);
        }       
        [Authorize(Policy = "Create Employee")]
        [HttpPost]
        public async Task<IActionResult> Them(NhanVienIndexVm nhanVienVM)
        {
            if (ModelState.IsValid)
            {
                await nhanVienService.ThemNhanVien(nhanVienVM.nhanVien);
                var user = await userManager.FindByNameAsync(nhanVienVM.nhanVien.Email);
                if (nhanVienVM.nhanVien.Role == 0)
                {
                    var permissionLibrarian = new List<Claim>(ClaimsStore.AllClaims);

                    permissionLibrarian.RemoveAt(6);
                    permissionLibrarian.RemoveAt(4);
                    permissionLibrarian.RemoveAt(3);
                    var claim = await userManager.AddClaimsAsync(user, permissionLibrarian);
                    if (claim.Succeeded)
                    {
                        //TempData là dữ liệu tạm thời chỉ tồn tại trong 1 lần, Reload lại sẽ không còn
                        //TempData sẽ được bắt ở Method Index và truyền qua Page View
                        //Tạo TempData khi Thêm thành công
                        //Quy định Thêm sẽ là 1
                        TempData["NhanVien"] = 1;
                        return RedirectToAction("Index");
                    }
                    TempData["NhanVien"] = 2;
                    return RedirectToAction("Index");
                }
                else
                {
                    var permissionAdmin = new List<Claim>(ClaimsStore.AllClaims);
                    permissionAdmin.RemoveAt(5);
                    var claim = await userManager.AddClaimsAsync(user, permissionAdmin);
                    if (claim.Succeeded)
                    {
                        //Tạo TempData khi Thêm thành công
                        //Quy định Thêm sẽ là 1
                        TempData["NhanVien"] = 1;
                        return RedirectToAction("Index");
                    }
                    TempData["NhanVien"] = 2;
                    return RedirectToAction("Index");
                }
            }
            TempData["NhanVien"] = 2;
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "Edit Employee")]
        [HttpPost]
        public async Task<IActionResult> Sua(NhanVienIndexVm nhanVienVM)
        {
            if (ModelState.IsValid)
            {
                await nhanVienService.SuaNhanVien(nhanVienVM.nhanVien);
                //Tạo TempData khi Sửa thành công
                TempData["NhanVien"] = 3;
                return RedirectToAction("Index");
            }
            TempData["NhanVien"] = 4;
            return RedirectToAction("Index");
        }
        [Authorize(Policy = "Edit Employee")]
        [HttpPost]
        public async Task<IActionResult> Permission(NhanVienIndexVm vm)
        {
            var user = await userManager.FindByIdAsync(vm.nhanVien.Id.ToString());

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with ID= {vm.nhanVien.Id} not found.";
                TempData["NhanVien"] = 6;
                return RedirectToAction("Index");
            }

            var currentUserClaims = await userManager.GetClaimsAsync(user);
            /*var result = await userManager.RemoveClaimsAsync(user, currentUserClaims);

            if(!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Can't remove existing user claims");
                return View(model);
            }*/

            // result = await userManager.AddClaimsAsync(user, 
            //    model.UserClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, "true")));

            if (currentUserClaims.Any(c => c.Type == "Role" && c.Type == "Admin"))
            {
                if (vm.nhanVien.Role == Role.Librarian)
                {
                    vm.nhanVien.UserClaims.RemoveRange(3, 2);
                    var result = await userManager.RemoveClaimsAsync(user, currentUserClaims);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Can't remove existing user claims");
                        TempData["NhanVien"] = 6;
                        return RedirectToAction("Index", vm);
                    }
                    result = await userManager.AddClaimsAsync(user,
                    vm.nhanVien.UserClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected.ToString().ToLower() )));
                    var result1 = await userManager.AddClaimAsync(user, new Claim("Role", "Librarian"));
                    if (!result.Succeeded && !result1.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Can't add user claims");
                        TempData["NhanVien"] = 6;
                        return RedirectToAction("Index", vm);
                    }
                    await signInManager.RefreshSignInAsync(await userManager.FindByNameAsync(User.Identity.Name));
                    //Tạo TempData khi Sửa Quyền thành công
                    //Những cái khác thêm,sửa mặc định mọi người có thể cho các giá trị khác
                    //tăng đều cho dễ làm
                    TempData["NhanVien"] = 5;
                    return RedirectToAction("Index");
                }
            }
            else
            {
                var result = await userManager.RemoveClaimsAsync(user, currentUserClaims);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Can't remove existing user claims");
                    TempData["NhanVien"] = 6;
                    return RedirectToAction("Index", vm);
                }
                result = await userManager.AddClaimsAsync(user,
                vm.nhanVien.UserClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.IsSelected.ToString().ToLower() )));
                var result1 = await userManager.AddClaimAsync(user, new Claim("Role", vm.nhanVien.Role.ToString()));
                if (!result.Succeeded && !result1.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Can't add user claims");
                    TempData["NhanVien"] = 6;
                    return RedirectToAction("Index", vm);
                }
                await signInManager.RefreshSignInAsync(await userManager.FindByNameAsync(User.Identity.Name));
                //Tạo TempData khi Sửa thành công
                TempData["NhanVien"] = 5;
                return RedirectToAction("Index", vm);
            }
            TempData["NhanVien"] = 6;
            return View();
        }
    }
}
