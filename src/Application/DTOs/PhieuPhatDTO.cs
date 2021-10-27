using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class PhieuPhatDTO
    {
        public int MaPP { get; set; }

        public int MaDG { set; get; }

        public int TongPhiPhat { set; get; }

        public int UserId { set; get; }
        public List<ChiTietPhieuPhatDTO> ChiTietPhieuPhats { get; set; }
        public int TrangThai { set; get; }
    }
}
