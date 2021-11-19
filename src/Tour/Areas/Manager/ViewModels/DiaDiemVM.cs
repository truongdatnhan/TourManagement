using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class DiaDiemVM 
    {
        public PaginatedList<DiaDiemDTO> DiaDiems { get; set; }
        public DiaDiemDTO DiaDiem { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
