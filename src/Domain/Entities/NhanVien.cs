using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class NhanVien
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public ICollection<PhanBoNhanVienDoan> PhanBoNhanVienDoans { get; set; }
    }
}
