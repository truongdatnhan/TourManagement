using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTOs
{
    public class ChiTietPhieuPhatDTO
    {
        public int MaPP { set; get; }
        public int MaSach { set; get; }
        public string NoiDungViPham { set; get; }
        public string XuLyViPham { set; get; }
        public int PhiPhat { set; get; }
        public bool IsSelected { get; set; }    
    }
}
