using Application.DTOs;
using ThuVien.Helper;

namespace ThuVien.Areas.Manager.ViewModels
{
    public class LoaiHinhDuLichVM 
    {
        public PaginatedList<LoaiHinhDuLichDTO> LoaiHinhDuLichs { get; set; }
        public LoaiHinhDuLichDTO LoaiHinhDuLich { get; set; }
        public string SearchString { get; set; }
        public string SortOrder { get; set; }
        
    }
}
