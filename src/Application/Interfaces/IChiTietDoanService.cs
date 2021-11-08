using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IChiTietDoanService
    {
        IEnumerable<ChiTietDoanDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        void Create(ChiTietDoanDTO dto);
        ChiTietDoanDTO Get(int maCTD);
        void Update(ChiTietDoanDTO dto);
        void Delete(int maCTD);
    }
}
