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
    public class TourDuLichController : Controller
    {
        private readonly ITourDuLichService tourDuLichService;
        private readonly ILoaiHinhDuLichService loaiHinhDuLichService;

        public TourDuLichController(ITourDuLichService tourDuLichService, ILoaiHinhDuLichService loaiHinhDuLichService)
        {
            this.tourDuLichService = tourDuLichService;
            this.loaiHinhDuLichService = loaiHinhDuLichService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsTour = tourDuLichService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var tour = new TourDuLichDTO();
            var VM = new TourDuLichVM()
            {
                Tours = new PaginatedList<TourDuLichDTO>(dsTour, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                Tour = tour
            };
            ViewBag.LoaiHinh = loaiHinhDuLichService.GetDTOs();
            return View(VM);
        }

        public IActionResult Create(TourDuLichVM vm)
        {
            if (ModelState.IsValid)
            {
                tourDuLichService.Create(vm.Tour);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(TourDuLichVM vm)
        {
            if (ModelState.IsValid)
            {
                tourDuLichService.Update(vm.Tour);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
