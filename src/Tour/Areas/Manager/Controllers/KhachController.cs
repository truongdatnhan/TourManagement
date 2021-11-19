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
    public class KhachController : Controller
    {
        private readonly IKhachService khachService;

        public KhachController(IKhachService khachService)
        {
            this.khachService = khachService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsK = khachService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var k = new KhachDTO();
            var VM = new KhachVM()
            {
                Khachs = new PaginatedList<KhachDTO>(dsK, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                Khach = k
            };
            return View(VM);
        }

        public IActionResult Create(KhachVM vm)
        {
            if(ModelState.IsValid)
            {
                khachService.Create(vm.Khach);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
