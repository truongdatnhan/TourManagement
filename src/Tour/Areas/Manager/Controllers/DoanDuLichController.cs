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
    public class DoanDuLichController : Controller
    {
        private readonly IDoanDuLichService doanDuLichService;
        private readonly ITourDuLichService tourDuLichService;
        private readonly INoiDungTourService noiDungTourService;

        public DoanDuLichController(IDoanDuLichService doanDuLichService,ITourDuLichService tourDuLichService,INoiDungTourService noiDungTourService)
        {
            this.doanDuLichService = doanDuLichService;
            this.tourDuLichService = tourDuLichService;
            this.noiDungTourService = noiDungTourService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsDoan = doanDuLichService.GetDTOs(sortOrder, searchString, pageIndex, pageSize,out count);
            var ddl = new DoanDuLichDTO();
            var VM = new DoanDuLichVM()
            {
                DoanDuLiches = new PaginatedList<DoanDuLichDTO>(dsDoan, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                DoanDuLich = ddl
            };
            ViewBag.Tour = tourDuLichService.GetDTOs();
            return View(VM);
        }

        public IActionResult Create(DoanDuLichVM vm)
        {
            if (ModelState.IsValid)
            {
                doanDuLichService.Create(vm.DoanDuLich);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(DoanDuLichVM vm)
        {
            if (ModelState.IsValid)
            {
                doanDuLichService.Update(vm.DoanDuLich);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult NoiDungTour(DoanDuLichVM vm)
        {
            if (ModelState.IsValid)
            {
                noiDungTourService.Create(vm.DoanDuLich.NoiDungTour);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
