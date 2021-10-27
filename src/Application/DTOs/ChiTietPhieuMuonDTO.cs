using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class ChiTietPhieuMuonDTO
    {
        public int MaPM { set; get; }
        public int MaSach { set; get; }
        public int PhiMuon { set; get; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NgayHetHan { set; get; }
        [DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime GiaHan { set; get; }
        public bool IsSelected { get; set; }
        public int TrangThai { set; get; }
    }
}
