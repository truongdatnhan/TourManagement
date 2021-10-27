using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;

namespace ThuVien.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> userManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(IAccountService accountService, UserManager<AppUser> userManager,ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            _accountService = accountService;
            this.logger = logger;
        }

        [Route("SignUp")]
        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        /*[Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpDTO signUpDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateUserAsync(signUpDTO);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(signUpDTO);
                }

                ModelState.Clear();
                return RedirectToAction("Login", "Account");
            }

            return View(signUpDTO);
        }*/

        [Route("SignUp")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpDTO signUpDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateUserAsync(signUpDTO);
                if (!result.Succeeded)
                {
                    foreach (var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View(signUpDTO);
                }
                var user = await userManager.FindByNameAsync(signUpDTO.Email);
                if(signUpDTO.Role == 0)
                {
                    var permissionLibrarian = new List<Claim>(ClaimsStore.AllClaims);

                    permissionLibrarian.RemoveAt(6);
                    permissionLibrarian.RemoveAt(4);
                    permissionLibrarian.RemoveAt(3);
                    var claim = await userManager.AddClaimsAsync(user, permissionLibrarian);
                    if (claim.Succeeded)
                    {
                        System.Diagnostics.Debug.WriteLine(claim);
                        TempData["SignUp"] = 1;
                        return RedirectToAction("Login", "Account");
                    }
                    return View(signUpDTO);
                } else
                {
                    var permissionAdmin = new List<Claim>(ClaimsStore.AllClaims);
                    permissionAdmin.RemoveAt(5);
                    var claim = await userManager.AddClaimsAsync(user, permissionAdmin);
                    if (claim.Succeeded)
                    {
                        System.Diagnostics.Debug.WriteLine(claim);
                        TempData["SignUp"] = 1;
                        return RedirectToAction("Login", "Account");
                    }
                    return View(signUpDTO);
                }
                //var claim = await userManager.AddClaimAsync(user, new System.Security.Claims.Claim("Admin", "Admin"));
                
                
            }
            ModelState.AddModelError(string.Empty, "Vui lòng điền đầy đủ thông tin");
            return View(signUpDTO);
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.SignUp = Convert.ToInt32(TempData["SignUp"]);
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LogInDTO logInDTO, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.PasswordSignInAsync(logInDTO);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToRoute("Manager");
                    }
                }

                ModelState.AddModelError(string.Empty, "Thông tin đăng nhập không hợp lệ.");
            }

            return View(logInDTO);
        }

        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Permission(string userID)
        {
            var user = await userManager.FindByIdAsync(userID);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with ID= {userID} not found.";
                RedirectToAction("index");
            }

            var currentUserClaims = await userManager.GetClaimsAsync(user);
            var model = new UserClaimsViewModel
            {
                UserID = userID
            };

            foreach(Claim claim in ClaimsStore.AllClaims.Where(c => c.Type != "Role") )
            {
                var userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                if(currentUserClaims.Any(c => c.Type == claim.Type) )
                {
                    userClaim.IsSelected = true;
                }
                model.UserClaims.Add(userClaim);
            }

            if(currentUserClaims.Any(c => c.Type == "Role" && c.Value == "Librarian") )
            {
                model.role = Role.Librarian;
                model.UserClaims.RemoveRange(3, 2);
            } else
            {
                if(currentUserClaims.Any(c => c.Type == "Role" && c.Value == "Admin") )
                {
                    model.role = Role.Admin;
                }
                
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Permission(UserClaimsViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserID);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with ID= {model.UserID} not found.";
                RedirectToAction("index");
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
                if (model.role == Role.Librarian)
                {
                    model.UserClaims.RemoveRange(3, 2);
                    var result = await userManager.RemoveClaimsAsync(user, currentUserClaims);

                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Can't remove existing user claims");
                        return View(model);
                    }
                    result = await userManager.AddClaimsAsync(user,
                    model.UserClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, "true")));
                    var result1 = await userManager.AddClaimAsync(user, new Claim("Role", "Librarian"));
                    if (!result.Succeeded && !result1.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, "Can't add user claims");
                        return View(model);
                    }
                }
            }
            else
            {
                var result = await userManager.RemoveClaimsAsync(user, currentUserClaims);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Can't remove existing user claims");
                    return View(model);
                }
                result = await userManager.AddClaimsAsync(user,
                model.UserClaims.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, "true")));
                var result1 = await userManager.AddClaimAsync(user, new Claim("Role", model.role.ToString()));
                if (!result.Succeeded && !result1.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Can't add user claims");
                    return View(model);
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        public async Task<IActionResult> Info()
        {
            var model = await userManager.GetUserAsync(HttpContext.User);

            return View(model);
        }
        /*public async Task<string> Test()
        {
            var model = await userManager.GetUserAsync(HttpContext.User);
            if(HttpContext.User == null)
            {
                if(model == null)
                {
                    return "model null";
                }
                return "chưa có session claim";
            } else
            {
                return model.HoNV +" "+ model.TenNV;
            }
            
        }*/

    }
}