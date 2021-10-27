using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class SachDTO
    {
        [Required(ErrorMessage = "Mã sách")]
        [Display(Name = "Mã sách")]
        public int MaSach { set; get; }
        [Required(ErrorMessage = "Tên sách")]
        [Display(Name = "Tên sách")]
        public string TenSach { set; get; }
        [Required(ErrorMessage = "Mã tác giả")]
        public int MaTG { set; get; }
        public string TenTG { set; get; }
        [Required(ErrorMessage = "Mã nhà xuất bản")]
        public int MaNXB { set; get; }
        public string TenNXB { get; set; }
        [Required(ErrorMessage = "Mã thể loại")]
        public int MaTL { set; get; }
        public string TenTL { set; get; }
        [Required(ErrorMessage = "Giá bìa")]
        public int GiaBia { set; get; }
        [Required(ErrorMessage = "Khu")]
        public int Khu { get; set; }
        [Required(ErrorMessage = "Tầng")]
        public int Tang { get; set; }
        [Required(ErrorMessage = "Kệ")]
        public int Ke { get; set; }
        public IFormFile SachImage { set; get; }
        public string SachImageUrl { get; set; }

    }
}