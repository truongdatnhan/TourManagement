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
    public class GiaTourController : Controller
    {
        private readonly IGiaTourService giaTourService;

        public GiaTourController(IGiaTourService giaTourService)
        {
            this.giaTourService = giaTourService;
        }

        public IActionResult Index(string maTour)
        {
            if(maTour == null)
            {
                return RedirectToAction("Index","DoanDuLich");
            }

            int pageSize = 8;
            int pageIndex = 1;
            int count;
            var dsGia = giaTourService.GetDTOs(null, null, pageIndex, pageSize, out count).Where(x => x.MaTour == Int32.Parse(maTour));
            //int count = dsDoan_Khach.Count();
            var gia = new GiaTourDTO();
            var VM = new GiaTourVM()
            {
                GiaTours = new PaginatedList<GiaTourDTO>(dsGia, count, pageIndex, pageSize),
                SearchString = null,
                SortOrder = null,
                GiaTour = gia
            };
            ViewBag.MaTour = maTour;
            return View(VM);
        }

        public IActionResult Create(GiaTourVM vm)
        {
            if (ModelState.IsValid)
            {
                giaTourService.Create(vm.GiaTour);
                return RedirectToAction("Index", new { maTour = vm.GiaTour.MaTour});
            }
            return RedirectToAction("Index", "TourDuLich");
        }

        public IActionResult Update(GiaTourVM vm)
        {
            if (ModelState.IsValid)
            {
                giaTourService.Update(vm.GiaTour);
                return RedirectToAction("Index", new { maTour = vm.GiaTour.MaTour });
            }
            return RedirectToAction("Index", "TourDuLich");
        }
    }
}
