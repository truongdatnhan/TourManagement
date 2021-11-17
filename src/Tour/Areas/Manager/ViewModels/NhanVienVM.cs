using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class NhanVienVM 
    {
        public PaginatedList<NhanVienDTO> NhanViens { get; set; }
        public NhanVienDTO NhanVien { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
