using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IChiPhiService
    {
        IEnumerable<ChiPhiDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        void Create(ChiPhiDTO dto);
        ChiPhiDTO Get(int maCP);
        void Update(ChiPhiDTO dto);
        void Delete(int maCP);
    }
}
