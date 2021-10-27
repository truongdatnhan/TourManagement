using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class PhieuMuon
    {
        public int MaPM { set; get; }
        public DocGia DocGia { get; set; }
        public int MaDG { set; get; }
        public DateTime NgayMuon { set; get; }
        public int TongPhiMuon { set; get; }
        public List<ChiTietPhieuMuon> ChiTietPhieuMuons { get; set; }
        public AppUser AppUser { get; set; }
        public int UserId { set; get; }
        public int TrangThai { set; get; }
    }
}