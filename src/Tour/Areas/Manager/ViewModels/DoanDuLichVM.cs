using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DoanDuLichVM 
    {
        public PaginatedList<DoanDuLichDTO> DoanDuLiches { get; set; }
        public DoanDuLichDTO DoanDuLich { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
