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
    public class LoaiHinhDuLichController : Controller
    {
        private readonly ILoaiHinhDuLichService loaiHinhDuLichService;

        public LoaiHinhDuLichController(ILoaiHinhDuLichService loaiHinhDuLichService)
        {
            this.loaiHinhDuLichService = loaiHinhDuLichService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsLHDL= loaiHinhDuLichService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var lhdl = new LoaiHinhDuLichDTO();
            var VM = new LoaiHinhDuLichVM()
            {
                LoaiHinhDuLichs = new PaginatedList<LoaiHinhDuLichDTO>(dsLHDL, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                LoaiHinhDuLich = lhdl
            };
            return View(VM);
        }

        public IActionResult Create(LoaiHinhDuLichVM vm)
        {
            if(ModelState.IsValid)
            {
                loaiHinhDuLichService.Create(vm.LoaiHinhDuLich);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
