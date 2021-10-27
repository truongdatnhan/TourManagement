using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class DocGia
    {
        public int MaDG { set; get; }
        public string HoDG { set; get; }
        public string TenDG { set; get; }
        public DateTime DoBDG { set; get; }
        public string EmailDG { set; get; }
        public string DiaChiDG { set; get; }
        public DateTime NgayDK { set; get; }
        public DateTime NgayHetHanDK { set; get; }
        public string TrangThaiThe { set; get; }
        public List<PhieuMuon> PhieuMuons { get; set; }
        public List<PhieuPhat> PhieuPhats { get; set; }
    }
}