using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class PhieuMuonIndexVm
    {
        public PaginatedList<PhieuMuonDTO> PhieuMuons { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public PhieuMuonDTO phieumuon { get; set; }
        public ChiTietPhieuMuonDTO ctpm{ get; set; }
        // tối đa đang mượn là 5 quyền
    }
}
