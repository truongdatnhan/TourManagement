using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class PhieuMuonDTO
    {

        public int MaPM { get; set; }

        public int MaDG { set; get; }

        [DataType(DataType.Date)]
        public DateTime NgayMuon { set; get; }

        public int TongPhiMuon { set; get; }

        public int UserId { set; get; }
        public int TrangThai { get; set; }
        public List<ChiTietPhieuMuonDTO> ChiTietPhieuMuons { get; set; }
    }
}
