using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ChiPhiDTO
    {

        [Display(Name = "Mã chi phí")]
        public int MaChiPhi { get; set; }
        [Display(Name = "Mã đoàn")]
        public int MaDoan { get; set; }
        [Display(Name = "Số tiền")]
        public long SoTien { get; set; }
        [Display(Name = "Mã loại chi phí")]
        public int MaLoaiChiPhi { get; set; }
        [Display(Name = "Tên loại chi phí")]
        public string TenLoaiChiPhi { get; set; }
    }
}
