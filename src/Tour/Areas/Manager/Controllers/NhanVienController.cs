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
    public class NhanVienController : Controller
    {
        private readonly INhanVienService nhanVienService;

        public NhanVienController(INhanVienService nhanVienService)
        {
            this.nhanVienService = nhanVienService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsNV = nhanVienService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var nv = new NhanVienDTO();
            var VM = new NhanVienVM()
            {
                NhanViens = new PaginatedList<NhanVienDTO>(dsNV, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                NhanVien = nv
            };
            return View(VM);
        }

        public IActionResult Create(NhanVienVM vm)
        {
            if(ModelState.IsValid)
            {
                nhanVienService.Create(vm.NhanVien);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(NhanVienVM vm)
        {
            if (ModelState.IsValid)
            {
                nhanVienService.Update(vm.NhanVien);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
