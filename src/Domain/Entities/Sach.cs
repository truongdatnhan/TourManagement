using System.Collections.Generic;

namespace Domain.Entities
{
    public class Sach
    {
        public int MaSach { set; get; }
        public string TenSach { set; get; }
        public TacGia TacGia { set; get; }
        public int MaTG { set; get; }
        public NhaXuatBan NhaXuatBan { set; get; }
        public int MaNXB { set; get; }
        public TheLoai TheLoai { set; get; }
        public int MaTL { set; get; }
        public int GiaBia { set; get; }
        public string SachImageUrl { set; get; }
        public int Khu { set; get; }
        public int Tang { set; get; }
        public int Ke { set; get; }
        public string TrangThaiSach { set; get; }
        public List<ChiTietPhieuMuon> ChiTietPhieuMuons { set; get; }
        public List<ChiTietPhieuPhat> ChiTietPhieuPhats { set; get; }
    }
}