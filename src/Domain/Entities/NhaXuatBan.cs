using System.Collections.Generic;

namespace Domain.Entities
{
    public class NhaXuatBan
    {
        public int MaNXB { set; get; }
        public string TenNXB { set; get; }
        public List<Sach> Sachs { get; set; }
    }
}