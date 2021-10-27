using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class TacGiaIndexVm
    {
        public PaginatedList<TacGiaDTO> TacGias { get; set; }
        public TacGiaDTO tacGia { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
    }
}