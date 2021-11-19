using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class GiaTourVM 
    {
        public PaginatedList<GiaTourDTO> GiaTours { get; set; }
        public GiaTourDTO GiaTour { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }

    }
}
