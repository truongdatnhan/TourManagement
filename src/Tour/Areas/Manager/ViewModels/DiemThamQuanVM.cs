using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DiemThamQuanVM
    {
        public PaginatedList<DiaDiemDTO> DiemThamQuans { get; set; }
        public DiemThamQuanDTO DiemThamQuan { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
