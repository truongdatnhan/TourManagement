using Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class KhachDTO
    {
        [Display(Name = "Mã khách hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }
        [Display(Name = "CMND")]
        public string SoCMND{ get; set; }
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
        [Display(Name = "Giới tính")]
        public Gender GioiTinh { get; set; }
        [Display(Name = "Số điện thoại")]
        public string SDT { get; set; }
        [Display(Name = "Quốc tịch")]
        public string QuocTich { get; set; }
        [Display(Name = "Vai trò")]
        public VaiTro VaiTro { get; set; }
    }
}
