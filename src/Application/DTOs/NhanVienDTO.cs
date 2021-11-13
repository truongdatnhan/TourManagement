using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class NhanVienDTO
    {
        [Display(Name = "M� nh�n vi�n")]
        public int MaNhanVien { get; set; }

        [Display(Name = "T�n nh�n vi�n")]
        [Required]
        public string TenNhanVien { get; set; }

        public string NhiemVu { get; set; }
    }
}
