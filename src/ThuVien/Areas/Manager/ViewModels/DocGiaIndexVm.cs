using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DocGiaIndexVm
    {
        public PaginatedList<DocGiaDTO> DocGias { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        public DocGiaDTO docgia { set; get; }
    }
}
