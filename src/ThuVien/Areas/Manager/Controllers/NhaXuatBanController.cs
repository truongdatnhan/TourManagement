using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class NhaXuatBanController : Controller
    {
        private readonly INhaXuatBanService nhaXuatBanService;

        public NhaXuatBanController(INhaXuatBanService nhaXuatBanService)
        {
            this.nhaXuatBanService = nhaXuatBanService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var nhaXuatBans = nhaXuatBanService.GetNhaXuatBans(sortOrder, searchString, pageIndex, pageSize, out count);
            var nhaXuatBanNew = new NhaXuatBanDTO();

            var nhaXuatBanVM = new NhaXuatBanIndexVm()
            {
                NhaXuatBans = new PaginatedList<NhaXuatBanDTO>(nhaXuatBans, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                nhaXuatBan = nhaXuatBanNew
            };
            ViewBag.NhaXuatBan = Convert.ToInt32(TempData["NhaXuatBan"]);
            return View(nhaXuatBanVM);
        }

        [HttpPost]
        public IActionResult Them(NhaXuatBanIndexVm nhaXuatBanVm)
        {
            if (ModelState.IsValid)
            {
                nhaXuatBanService.ThemNhaXuatBan(nhaXuatBanVm.nhaXuatBan);
                TempData["NhaXuatBan"] = 1;
                return RedirectToAction("Index");
            }
            TempData["NhaXuatBan"] = 4;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sua(NhaXuatBanIndexVm nhaXuatBanVm)
        {
            if (ModelState.IsValid)
            {
                nhaXuatBanService.SuaNhaXuatBan(nhaXuatBanVm.nhaXuatBan);
                TempData["NhaXuatBan"] = 2;
                return RedirectToAction("Index");
            }
            TempData["NhaXuatBan"] = 5;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Xoa(NhaXuatBanIndexVm nhaXuatBanVm)
        {
            nhaXuatBanService.XoaNhaXuatBan(nhaXuatBanVm.nhaXuatBan.MaNXB);
            TempData["NhaXuatBan"] = 3;
            return RedirectToAction("Index");
        }
    }
}