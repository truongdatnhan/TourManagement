﻿using Application.DTOs;
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
    public class DoanDuLichController : Controller
    {
        private readonly IDoanDuLichService doanDuLichService;
        private readonly ITourDuLichService tourDuLichService;

        public DoanDuLichController(IDoanDuLichService doanDuLichService,ITourDuLichService tourDuLichService)
        {
            this.doanDuLichService = doanDuLichService;
            this.tourDuLichService = tourDuLichService;
        }

        public IActionResult Index(string sortOrder, string searchString, int pageIndex = 1)
        {
            int pageSize = 8;
            int count;
            var dsDoan = doanDuLichService.GetDTOs(sortOrder, searchString, pageIndex, pageSize,out count);
            var ddl = new DoanDuLichDTO();
            var VM = new DoanDuLichVM()
            {
                DoanDuLiches = new PaginatedList<DoanDuLichDTO>(dsDoan, count, pageIndex, pageSize),
                SearchString = searchString,
                SortOrder = sortOrder,
                DoanDuLich = ddl
            };
            ViewBag.tour = tourDuLichService.GetDTOs();
            return View(VM);
        }
        public IActionResult ChiTietTour(string maDoan,string list)
        {
            if(maDoan == null)
            {
                return RedirectToAction("Index");
            }
            switch (list) 
            {
                case "khachhang":
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
                    ViewBag.tour = tourDuLichService.GetDTOs();
                    return View("Index_Khach",VM);
                default:
                    return RedirectToAction("Index");

            }

        }
    }
}