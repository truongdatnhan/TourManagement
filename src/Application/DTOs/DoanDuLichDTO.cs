using System;
using System.Collections.Generic;

namespace Application.DTOs
{
    public class DoanDuLichDTO
    {
        public int MaDoan { get; set; }
        public int MaTour { get; set; }
        public string TenTour { get; set; }
        public string TenDoan { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public long DoanhThu { get; set; }
        public NoiDungTourDTO NoiDungTour { get; set; }
        ICollection<KhachDTO> Khaches { get; set; }
        ICollection<ChiPhiDTO> ChiPhis { get; set; }
        ICollection<NhanVienDTO> NhanViens { get; set; }

    }
}
