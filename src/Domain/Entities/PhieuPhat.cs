using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PhieuPhat
    {
        public int MaPP { set; get; }
        public DocGia DocGia { set; get; }
        public int MaDG { set; get; }
        public int TongPhiPhat { set; get; }
        public List<ChiTietPhieuPhat> ChiTietPhieuPhats { get; set; }
        public AppUser AppUser { get; set; }
        public int UserId { set; get; }
        public int TrangThai { set; get; }
    }
}