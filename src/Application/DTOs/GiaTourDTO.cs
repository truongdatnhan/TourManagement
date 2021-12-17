using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class GiaTourDTO
    {
        [Display(Name = "Mã giá")]
        public int MaGia { get; set; }
        [Display(Name = "Mã tour")]
        public int MaTour { get; set; }
        [Display(Name = "Thành tiền")]
        public long ThanhTien { get; set; }
        [Display(Name = "Thời gian bắt đầu")]
        public DateTime ThoiGianBatDau { get; set; }
        [Display(Name = "Thời gian kết thúc")]
        public DateTime ThoiGianKetThuc { get; set; }
    }
}
