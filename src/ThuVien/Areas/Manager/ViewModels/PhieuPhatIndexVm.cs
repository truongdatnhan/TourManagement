using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class PhieuPhatIndexVm
    {
        public PaginatedList<PhieuPhatDTO> PhieuPhats { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public PhieuPhatDTO phieuphat { get; set; }
        public ChiTietPhieuPhatDTO ctpp { get; set; }
    }
}