using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INhanVienService
    {
        IEnumerable<NhanVienDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        bool Create(NhanVienDTO dto);
        NhanVienDTO Get(int maNV);
        bool Update(NhanVienDTO dto);
        bool Delete(int maNV);
    }
}
