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
    public class ChiTietDoanController : Controller
    {
        private readonly IDoanDuLichService doanDuLichService;
        private readonly ILoaiChiPhiService loaiChiPhiService;
        private readonly IChiPhiService chiPhiService;
        private readonly IChiTietDoanService chiTietDoanService;
        private readonly INhanVienService nhanVienService;
        private readonly IPhanBoNhanVienDoanService phanBoNhanVienDoanService;
        private readonly IKhachService khachService;

        public ChiTietDoanController(IDoanDuLichService doanDuLichService,ILoaiChiPhiService loaiChiPhiService,IChiPhiService chiPhiService,
            IChiTietDoanService chiTietDoanService,INhanVienService nhanVienService,IPhanBoNhanVienDoanService phanBoNhanVienDoanService,
            IKhachService khachService)
        {
            this.doanDuLichService = doanDuLichService;
            this.loaiChiPhiService = loaiChiPhiService;
            this.chiPhiService = chiPhiService;
            this.chiTietDoanService = chiTietDoanService;
            this.nhanVienService = nhanVienService;
            this.phanBoNhanVienDoanService = phanBoNhanVienDoanService;
            this.khachService = khachService;
        }

        public IActionResult Index(string maDoan,string list)
        {
            if(maDoan == null)
            {
                return RedirectToAction("Index","DoanDuLich");
            }
            switch (list) 
            {
                case "khachhang":
                    {
                        int pageSize = 8;
                        int pageIndex = 1;
                        var dsDoan_Khach = doanDuLichService.GetKhachsByDoan(Int32.Parse(maDoan));
                        int count = dsDoan_Khach.Count();
                        var kh = new KhachDTO();
                        var VM = new DoanDuLich_KhachVM()
                        {
                            Khaches = new PaginatedList<KhachDTO>(dsDoan_Khach, count, pageIndex, pageSize),
                            SearchString = null,
                            SortOrder = null,
                            Khach = kh
                        };
                        ViewBag.MaDoan = maDoan;
                        ViewBag.Khach = khachService.GetDTOs();
                        return View("Index_Khach", VM);
                    }
                case "nhanvien":
                    {
                        int pageSize = 8;
                        int pageIndex = 1;
                        var dsDoan_NV = doanDuLichService.GetNVsByDoan(Int32.Parse(maDoan));
                        int count = dsDoan_NV.Count();
                        var nv = new NhanVienDTO();
                        var VM = new DoanDuLich_NhanVienVM()
                        {
                            NhanViens = new PaginatedList<NhanVienDTO>(dsDoan_NV, count, pageIndex, pageSize),
                            SearchString = null,
                            SortOrder = null,
                            NhanVien = nv
                        };
                        ViewBag.MaDoan = maDoan;
                        ViewBag.NhanVien = nhanVienService.GetDTOs();
                        return View("Index_NhanVien", VM);
                    }
                case "chiphi":
                    {
                        int pageSize = 8;
                        int pageIndex = 1;
                        var dsDoan_CP = doanDuLichService.GetCPsByDoan(Int32.Parse(maDoan));
                        int count = dsDoan_CP.Count();
                        var cp = new ChiPhiDTO();
                        var VM = new DoanDuLich_ChiPhiVM()
                        {
                            ChiPhis = new PaginatedList<ChiPhiDTO>(dsDoan_CP, count, pageIndex, pageSize),
                            SearchString = null,
                            SortOrder = null,
                            ChiPhi = cp
                        };
                        ViewBag.MaDoan = maDoan;
                        ViewBag.LoaiChiPhi = loaiChiPhiService.GetDTOs();
                        return View("Index_ChiPhi", VM);
                    }
                default:
                    return RedirectToAction("Index", "DoanDuLich");

            }
        }

        #region Nhân Viên
        public IActionResult Create_NV(DoanDuLich_NhanVienVM vm)
        {
            if (ModelState.IsValid)
            {
                phanBoNhanVienDoanService.Create(vm.PhanBoNhanVienDoan);
                return RedirectToAction("Index", new { maDoan = vm.PhanBoNhanVienDoan.MaDoan, list = "nhanvien" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }

        public IActionResult Delete_NV(DoanDuLich_NhanVienVM vm)
        {
            if (ModelState.IsValid)
            {
                phanBoNhanVienDoanService.Delete(vm.PhanBoNhanVienDoan);
                return RedirectToAction("Index", new { maDoan = vm.PhanBoNhanVienDoan.MaDoan, list = "nhanvien" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }
        #endregion

        #region Chi Phí
        public IActionResult Create_CP(DoanDuLich_ChiPhiVM vm)
        {
            if (ModelState.IsValid)
            {
                chiPhiService.Create(vm.ChiPhi);
                return RedirectToAction("Index", new { maDoan = vm.ChiPhi.MaDoan,list= "chiphi" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }

        public IActionResult Update_CP(DoanDuLich_ChiPhiVM vm)
        {
            if (ModelState.IsValid)
            {
                chiPhiService.Update(vm.ChiPhi);
                return RedirectToAction("Index", new { maDoan = vm.ChiPhi.MaDoan, list = "chiphi" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }
        #endregion

        #region Khách
        public IActionResult Create_KH(DoanDuLich_KhachVM vm)
        {
            if (ModelState.IsValid)
            {
                chiTietDoanService.Create(vm.ChiTietDoan);
                doanDuLichService.UpdateDoanhThu(vm.ChiTietDoan.MaDoan);
                return RedirectToAction("Index", new { maDoan = vm.ChiTietDoan.MaDoan, list = "khachhang" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }

        public IActionResult Delete_KH(DoanDuLich_KhachVM vm)
        {
            if (ModelState.IsValid)
            {
                chiTietDoanService.Delete(vm.ChiTietDoan);
                doanDuLichService.UpdateDoanhThu(vm.ChiTietDoan.MaDoan);
                return RedirectToAction("Index", new { maDoan = vm.ChiTietDoan.MaDoan, list = "khachhang" });
            }
            return RedirectToAction("Index", "DoanDuLich");
        }
        #endregion

    }
}
