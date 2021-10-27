using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class TheLoaiIndexVm
    {
        public PaginatedList<TheLoaiDTO> TheLoais { get; set; }
        public TheLoaiDTO theLoai { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}