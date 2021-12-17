using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DiemThamQuanDTO
    {
        [Display(Name = "Mã tour")]
        public int MaTour { get; set; }
        [Display(Name = "Mã địa điểm")]
        public int MaDiaDiem { get; set; }
        [Display(Name = "Thứ tự")]
        public int ThuTu { get; set; }
    }
}
