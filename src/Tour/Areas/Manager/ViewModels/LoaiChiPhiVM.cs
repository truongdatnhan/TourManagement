using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class LoaiChiPhiVM 
    {
        public PaginatedList<LoaiChiPhiDTO> LoaiChiPhis { get; set; }
        public LoaiChiPhiDTO LoaiChiPhi { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }


    }
}
