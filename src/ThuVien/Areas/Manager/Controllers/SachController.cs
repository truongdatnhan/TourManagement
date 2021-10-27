using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Areas.Manager.ViewModels;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.Controllers
{
    [Area("Manager")]
    [Authorize]
    public class SachController : Controller
    {
        private readonly ISachService sachService;
        private readonly ITheLoaiRepository theLoaiRepository;
        private readonly ITacGiaRepository tacGiaRepository;
        private readonly INhaXuatBanRepository nhaXuatBanRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public SachController(ISachService sachService, ITheLoaiRepository theLoaiRepository,
            ITacGiaRepository tacGiaRepository, INhaXuatBanRepository nhaXuatBanRepository,
            IWebHostEnvironment webHostEnvironment)
        {
            this.sachService = sachService;
            this.theLoaiRepository = theLoaiRepository;
            this.tacGiaRepository = tacGiaRepository;
            this.nhaXuatBanRepository = nhaXuatBanRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var sachs = sachService.GetSachs(sortOrder, searchString, pageIndex, pageSize, out count);
            var sachNew = new SachDTO();

            var sachVM = new SachIndexVm()
            {
                Sachs = new PaginatedList<SachDTO>(sachs, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                sach = sachNew,
            };

            ViewBag.laytheloai = theLoaiRepository.LayTheLoai();
            ViewBag.laytacgia = tacGiaRepository.LayTacGia();
            ViewBag.laynxb = nhaXuatBanRepository.LayNXB();
            ViewBag.Sach = Convert.ToInt32(TempData["Sach"]);
            return View(sachVM);
        }

        [HttpPost]
        public IActionResult Them(SachIndexVm sachVM)
        {
            if (ModelState.IsValid)
            {
                if (sachVM.sach.SachImage != null)
                {
                    string folder = "sach/";
                    folder += Guid.NewGuid().ToString() + "_" + sachVM.sach.SachImage.FileName;

                    sachVM.sach.SachImageUrl = "/" + folder;

                    string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);

                    sachVM.sach.SachImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                }

                if(sachService.ThemSach(sachVM.sach))
                {
                    TempData["Sach"] = 1;
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Vui lòng điền đầy đủ thông tin");
            TempData["Sach"] = 4;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Sua(SachIndexVm sachVm)
        {
            if (ModelState.IsValid)
            {
                if(sachService.SuaSach(sachVm.sach))
                {
                    TempData["Sach"] = 2;
                    return RedirectToAction("Index");
                }
            }
            TempData["Sach"] = 5;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Xoa(SachIndexVm sachVm)
        {
            sachService.XoaSach(sachVm.sach.MaSach);
            TempData["Sach"] = 3;
            return RedirectToAction("Index");
        }
    }
}