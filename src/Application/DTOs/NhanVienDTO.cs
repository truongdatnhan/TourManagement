using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienDTO
    {
        [Display(Name = "Mã nhân viên")]
        public int MaNhanVien { get; set; }

        [Display(Name = "Tên nhân viên")]
        [Required]
        public string TenNhanVien { get; set; }

        public string NhiemVu { get; set; }
    }
}
