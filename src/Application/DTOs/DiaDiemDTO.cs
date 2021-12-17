using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DiaDiemDTO
    {
        [Display(Name = "Mã địa điểm")]
        public int MaDiaDiem { get; set; }
        [Display(Name = "Tên địa điểm")]
        public string TenDiaDiem { get; set; }
        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }
    }
}
