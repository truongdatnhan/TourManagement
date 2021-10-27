namespace Domain.Entities
{
    public class ChiTietPhieuPhat
    {
        public PhieuPhat PhieuPhat { get; set; }
        public int MaPP { set; get; }
        public Sach Sach { get; set; }
        public int MaSach { set; get; }
        public string NoiDungViPham { set; get; }
        public string XuLyViPham { set; get; }
        public int PhiPhat { set; get; }
    }
}