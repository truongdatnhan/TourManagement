using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class PhanBoNhanVienDoanDTO
    {
        [Display(Name = "Mã nhân viên")]
        public int MaNhanVien { get; set; }
        [Display(Name = "Mã đoàn")]
        public int MaDoan { get; set; }
        [Display(Name = "Nhiệm vụ")]
        public string NhiemVu { get; set; }
    }
}
