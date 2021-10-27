using System.Collections.Generic;

namespace Domain.Entities
{
    public class TacGia
    {
        public int MaTG { set; get; }    
        public string TenTG { set; get; }
        public List<Sach> Sachs { get; set; }
    }
}