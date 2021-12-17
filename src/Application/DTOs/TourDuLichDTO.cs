using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class TourDuLichDTO
    {
        [Display(Name = "Mã tour")]
        public int MaTour { get; set; }
        [Display(Name = "Tên gọi")]
        public string TenGoi { get; set; }
        [Display(Name = "Đặc điểm")]
        public string DacDiem { get; set; }
        [Display(Name = "Mã loại hình")]
        public int MaLoaiHinh { get; set; }
        [Display(Name = "Tên loại hình")]
        public string TenLoaiHinh { get; set; }
    }
}
