using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs

{
    public class NoiDungTourDTO
    {
        [Display(Name = "Mã đoàn")]
        public int MaDoan { get; set; }
        [Display(Name = "Hành trình")]
        public string HanhTrinh { get; set; }
        [Display(Name = "Khách sạn")]
        public string KhachSan { get; set; }
        [Display(Name = "Địa điểm tham quan")]
        public string DiaDiemThamQuan { get; set; }

    }
}
