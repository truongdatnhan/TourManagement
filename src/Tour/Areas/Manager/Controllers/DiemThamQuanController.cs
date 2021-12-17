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
    public class DiemThamQuanController : Controller
    {
        private readonly ITourDuLichService tourDuLichService;
        private readonly IDiaDiemService diaDiemService;
        private readonly IDiemThamQuanService diemThamQuanService;

        public DiemThamQuanController(ITourDuLichService tourDuLichService, IDiaDiemService diaDiemService,IDiemThamQuanService diemThamQuanService)
        {
            this.tourDuLichService = tourDuLichService;
            this.diaDiemService = diaDiemService;
            this.diemThamQuanService = diemThamQuanService;
        }

        public IActionResult Index(string maTour)
        {
            if(maTour == null)
            {
                return RedirectToAction("Index","TourDuLich");
            }
            int pageSize = 8;
            int pageIndex = 1;
            var dsDoan_DD = tourDuLichService.GetDiaDiemsByTour(Int32.Parse(maTour));
            int count = dsDoan_DD.Count();
            var dd = new DiemThamQuanDTO();
            var VM = new DiemThamQuanVM()
            {
                DiemThamQuans = new PaginatedList<DiaDiemDTO>(dsDoan_DD, count, pageIndex, pageSize),
                SearchString = null,
                SortOrder = null,
                DiemThamQuan = dd
            };
            ViewBag.MaTour = maTour;
            ViewBag.DiaDiem = diaDiemService.GetDTOs();
            return View("Index", VM);
        
        }

        #region Khách
        public IActionResult Create_DD(DiemThamQuanVM vm)
        {
            if (ModelState.IsValid)
            {
                diemThamQuanService.Create(vm.DiemThamQuan);
                return RedirectToAction("Index",new { maTour = vm.DiemThamQuan.MaTour });
            }
            return RedirectToAction("Index", "TourDuLich");
        }

        public IActionResult Delete_DD(DiemThamQuanVM vm)
        {
            if (ModelState.IsValid)
            {
                diemThamQuanService.Delete(vm.DiemThamQuan);
                return RedirectToAction("Index", new { maTour = vm.DiemThamQuan.MaTour });
            }
            return RedirectToAction("Index", "TourDuLich");
        }
        #endregion

    }
}
