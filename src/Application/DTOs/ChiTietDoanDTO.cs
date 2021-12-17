using Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ChiTietDoanDTO
    {
        [Display(Name = "Mã đoàn")]
        public int MaDoan { get; set; }
        [Display(Name = "Mã khách hàng")]
        public int MaKhachHang { get; set; }
        [Display(Name = "Vai trò")]
        public VaiTro VaiTro { get; set; }
    }
}
