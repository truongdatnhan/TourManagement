using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class LoaiChiPhiDTO
    {
        [Display(Name = "Mã loại chi phí")]
        public int MaLoaiChiPhi { get; set; }
        [Display(Name = "Tên loại chi phí")]
        public string TenLoaiChiPhi { get; set; }
    }
}
