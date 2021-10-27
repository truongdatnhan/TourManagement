using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class TheLoai
    {
        public int MaTL { set; get; }
        public string TenTL { set; get; }
        public List<Sach> Sachs { get; set; }
    }
}