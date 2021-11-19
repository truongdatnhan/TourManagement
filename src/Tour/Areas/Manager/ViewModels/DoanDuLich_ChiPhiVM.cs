using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DoanDuLich_ChiPhiVM
    {
        public PaginatedList<ChiPhiDTO> ChiPhis { get; set; }
        public ChiPhiDTO ChiPhi { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
