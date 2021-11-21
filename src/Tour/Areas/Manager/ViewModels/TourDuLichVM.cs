using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class TourDuLichVM 
    {
        public PaginatedList<TourDuLichDTO> Tours { get; set; }
        public TourDuLichDTO Tour { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
