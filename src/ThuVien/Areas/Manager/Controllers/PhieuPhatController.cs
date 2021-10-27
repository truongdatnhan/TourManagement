using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]

    public class PhieuPhatController : Controller
    {
        private readonly IPhieuPhatService phieuPhatService;
        private readonly ISachService sachService;

        public PhieuPhatController(IPhieuPhatService phieuphatService, ISachService sachService)
        {
            this.phieuPhatService = phieuphatService;
            this.sachService = sachService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsphieuphat = phieuPhatService.GetPhieuPhats(sortOrder, searchString, pageIndex, pageSize, out count);
            var phieuphat = new PhieuPhatDTO();
            var ctpp = new ChiTietPhieuPhatDTO();

            var phieuphatVM = new PhieuPhatIndexVm()
            {
                PhieuPhats = new PaginatedList<PhieuPhatDTO>(dsphieuphat, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                phieuphat = phieuphat,
                ctpp = ctpp
            };
            ViewBag.PhieuPhat = Convert.ToInt32(TempData["PhieuPhat"]);
            return View(phieuphatVM);
        }
        [HttpPost]
        public IActionResult Create(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                if(phieuPhatService.CreatePhieuPhat(vm.phieuphat) == true )
                {
                    TempData["PhieuPhat"] = 1;
                    return RedirectToAction("Index");
                }   
            }
            TempData["PhieuPhat"] = 2;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                phieuPhatService.UpdatePhieuPhat(vm.phieuphat);
                TempData["PhieuPhat"] = 3;
                return RedirectToAction("Index");
            }
            TempData["PhieuPhat"] = 4;
            return RedirectToAction("Index");
        }

       /*[HttpPost]
        public IActionResult Delete(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                phieuPhatService.DeletePhieuPhat(vm.phieuphat.MaPP);
                TempData["PhieuPhat"] = 3;
                return RedirectToAction("Index");
            }
            TempData["PhieuPhat"] = 6;
            return View();
        }*/

        [HttpPost]
        public IActionResult CreateCTPP(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                if(phieuPhatService.AddCTPP(vm.ctpp) == true)
                {
                    TempData["PhieuPhat"] = 5;
                    return RedirectToAction("Index");
                }
            }
            TempData["PhieuPhat"] = 6;
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult UpdateCTPP(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                phieuPhatService.AddCTPP(vm.ctpp);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult DeleteCTPP(PhieuPhatIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                phieuPhatService.DeleteCTPP(vm.phieuphat.ChiTietPhieuPhats);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
