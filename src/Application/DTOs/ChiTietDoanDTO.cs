using Domain.Entities.Enum;

namespace Application.DTOs
{
    public class ChiTietDoanDTO
    {
        public int MaDoan { get; set; }
        public int MaKhachHang { get; set; }
        public VaiTro VaiTro { get; set; }
    }
}
