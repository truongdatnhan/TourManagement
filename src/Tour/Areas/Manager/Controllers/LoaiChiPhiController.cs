using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace Tour.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class LoaiChiPhiController : Controller
    {
        private readonly ILoaiChiPhiService loaiChiPhiService;

        public LoaiChiPhiController(ILoaiChiPhiService loaiChiPhiService)
        {
            this.loaiChiPhiService = loaiChiPhiService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsLCP = loaiChiPhiService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var lcp = new LoaiChiPhiDTO();
            var VM = new LoaiChiPhiVM()
            {
                LoaiChiPhis = new PaginatedList<LoaiChiPhiDTO>(dsLCP, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                LoaiChiPhi = lcp
            };

            return View(VM);
        }

        public IActionResult Create(LoaiChiPhiVM vm)
        {
            if(ModelState.IsValid)
            {
                loaiChiPhiService.Create(vm.LoaiChiPhi);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(LoaiChiPhiVM vm)
        {
            if (ModelState.IsValid)
            {
                loaiChiPhiService.Update(vm.LoaiChiPhi);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
