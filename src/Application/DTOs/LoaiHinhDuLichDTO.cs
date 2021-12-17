using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class LoaiHinhDuLichDTO
    {
        [Display(Name = "Mã loại hình")]
        public int MaLoaiHinh { get; set; }
        [Display(Name = "Tên loại hình")]
        public string TenLoaiHinh { get; set; }
    }
}
