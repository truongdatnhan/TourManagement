using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class TheLoaiController : Controller
    {
        private readonly ITheLoaiService theLoaiService;

        public TheLoaiController(ITheLoaiService theLoaiService)
        {
            this.theLoaiService = theLoaiService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var theLoais = theLoaiService.GetTheLoais(sortOrder, searchString, pageIndex, pageSize, out count);
            var theLoaiNew = new TheLoaiDTO();

            var theLoaiVM = new TheLoaiIndexVm()
            {
                TheLoais = new PaginatedList<TheLoaiDTO>(theLoais, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                theLoai = theLoaiNew
            };
            ViewBag.TheLoai = Convert.ToInt32(TempData["TheLoai"]);
            return View(theLoaiVM);
        }

        [HttpPost]
        public IActionResult Them(TheLoaiIndexVm theLoaiVM)
        {
            if (ModelState.IsValid)
            {
                theLoaiService.ThemTheLoai(theLoaiVM.theLoai);
                TempData["TheLoai"] = 1;
                return RedirectToAction("Index");
            }
            TempData["TheLoai"] = 4;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sua(TheLoaiIndexVm theLoaiVm)
        {
            if (ModelState.IsValid)
            {
                theLoaiService.SuaTheLoai(theLoaiVm.theLoai);
                TempData["TheLoai"] = 2;
                return RedirectToAction("Index");
            }
            TempData["TheLoai"] = 5;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Xoa(TheLoaiIndexVm theLoaiVm)
        {
            theLoaiService.XoaTheLoai(theLoaiVm.theLoai.MaTL);
            TempData["TheLoai"] = 3;
            return RedirectToAction("Index");
        }
    }
}