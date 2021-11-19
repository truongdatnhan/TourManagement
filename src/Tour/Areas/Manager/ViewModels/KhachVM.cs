using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class KhachVM 
    {
        public PaginatedList<KhachDTO> Khachs { get; set; }
        public KhachDTO Khach { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
