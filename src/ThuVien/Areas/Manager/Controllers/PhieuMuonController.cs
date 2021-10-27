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

namespace QLTV.Controllers
{
    [Area("Manager")]
    //[Route("[Area]/[Controller]/[Action]")]
    [Authorize]
    public class PhieuMuonController : Controller
    {
        private readonly IPhieuMuonService phieuMuonService;
        private readonly ISachService sachService;

        public PhieuMuonController(IPhieuMuonService phieumuonService, ISachService sachService)
        {
            this.phieuMuonService = phieumuonService;
            this.sachService = sachService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
         
            int pageSize = 8;
            int count;
            var dsphieumuon = phieuMuonService.GetPhieuMuons(sortOrder, searchString, pageIndex, pageSize, out count);
            var phieumuon = new PhieuMuonDTO();
            var ctpm = new ChiTietPhieuMuonDTO();
            var listSach = sachService.GetSachs(sortOrder, searchString, pageIndex, pageSize, out count);
            var phieumuonVM = new PhieuMuonIndexVm()
            {
               PhieuMuons = new PaginatedList<PhieuMuonDTO>(dsphieumuon, count, pageIndex, pageSize),
               SearchString = searchString,
               SortOrder = sortOrder,
               phieumuon = phieumuon,
               ctpm = ctpm
            };
            ViewBag.PhieuMuon = Convert.ToInt32(TempData["PhieuMuon"]);
            return View(phieumuonVM);
            
        }

        [HttpPost]
        public IActionResult Create(PhieuMuonIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                if(phieuMuonService.CreatePhieuMuon(vm.phieumuon) == true)
                {
                    TempData["PhieuMuon"] = 1;
                    return RedirectToAction("Index");
                }
            }
            TempData["PhieuMuon"] = 2;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(PhieuMuonIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                if(phieuMuonService.UpdatePhieuMuon(vm.phieumuon) == true)
                {
                    TempData["PhieuMuon"] = 3;
                    return RedirectToAction("Index");
                }
            }
            TempData["PhieuMuon"] = 4;
            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        public IActionResult Delete(PhieuMuonIndexVm vm)
        {
            if(ModelState.IsValid)
            {
                phieuMuonService.DeletePhieuMuon(vm.phieumuon.MaPM);
                TempData["PhieuMuon"] = 3;
                return RedirectToAction("Index");
            }
            TempData["PhieuMuon"] = 6;
            return RedirectToAction("Index");
        } */

        [HttpPost]
        public IActionResult CreateCTPM(PhieuMuonIndexVm vm)
        {
            if(ModelState.IsValid)
            {
                if (phieuMuonService.AddCTPM(vm.ctpm) == true)
                {
                    TempData["PhieuMuon"] = 5;
                    return RedirectToAction("Index");
                }
            }
            TempData["PhieuMuon"] = 6;
            return RedirectToAction("Index");
        }
        
        /*[HttpPost]
        public IActionResult UpdateCTPM(PhieuMuonIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                phieuMuonService.AddCTPM(vm.ctpm);
                return RedirectToAction("Index");
            }
            return View();
        }*/

        [HttpPost]
        public IActionResult DeleteCTPM(PhieuMuonIndexVm vm)
        {
            if (ModelState.IsValid)
            {
                if(phieuMuonService.DeleteCTPM(vm.phieumuon.ChiTietPhieuMuons))
                {
                    TempData["PhieuMuon"] = 7;
                    return RedirectToAction("Index");
                }
            }
            TempData["PhieuMuon"] = 8;
            return RedirectToAction("Index");
        }
    }
}