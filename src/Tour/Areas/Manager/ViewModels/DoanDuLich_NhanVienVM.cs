using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DoanDuLich_NhanVienVM
    {
        public PaginatedList<NhanVienDTO> NhanViens { get; set; }
        public NhanVienDTO NhanVien { get; set; }
        public PhanBoNhanVienDoanDTO PhanBoNhanVienDoan { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
