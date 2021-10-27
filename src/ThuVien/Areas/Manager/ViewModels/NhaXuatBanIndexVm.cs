using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class NhaXuatBanIndexVm
    {
        public PaginatedList<NhaXuatBanDTO> NhaXuatBans { get; set; }
        public NhaXuatBanDTO nhaXuatBan { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}