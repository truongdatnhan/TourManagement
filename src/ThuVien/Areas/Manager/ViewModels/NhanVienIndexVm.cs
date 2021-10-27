using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class NhanVienIndexVm 
    {
        public PaginatedList<NhanVienDTO> NhanViens { get; set; }
        public NhanVienDTO nhanVien { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
