using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class DoanDuLichDTO
    {
        [Display(Name = "Mã đoàn")]
        public int MaDoan { get; set; }
        [Display(Name = "Mã tour")]
        public int MaTour { get; set; }
        [Display(Name = "Tên tour")]
        public string TenTour { get; set; }
        [Display(Name = "Tên đoàn")]
        public string TenDoan { get; set; }
        [Display(Name = "Ngày khởi hành")]
        public DateTime NgayKhoiHanh { get; set; }
        [Display(Name = "Ngày kết thúc")]
        public DateTime NgayKetThuc { get; set; }
        [Display(Name = "Doanh thu")]
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public long DoanhThu { get; set; }
        [Display(Name = "Nội dung tour")]
        public NoiDungTourDTO NoiDungTour { get; set; }
    }
}
