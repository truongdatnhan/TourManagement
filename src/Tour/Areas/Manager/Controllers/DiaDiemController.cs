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
    public class DiaDiemController : Controller
    {
        private readonly IDiaDiemService diaDiemService;

        public DiaDiemController(IDiaDiemService diaDiemService)
        {
            this.diaDiemService = diaDiemService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsDD = diaDiemService.GetDTOs(sortOrder, searchString, pageIndex, pageSize, out count);
            var dd = new DiaDiemDTO();
            var VM = new DiaDiemVM()
            {
                DiaDiems = new PaginatedList<DiaDiemDTO>(dsDD, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                DiaDiem = dd
            };
            return View(VM);
        }

        public IActionResult Create(DiaDiemVM vm)
        {
            if(ModelState.IsValid)
            {
                diaDiemService.Create(vm.DiaDiem);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(DiaDiemVM vm)
        {
            if (ModelState.IsValid)
            {
                diaDiemService.Update(vm.DiaDiem);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
