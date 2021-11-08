using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IChiPhiService
    {
        IEnumerable<ChiPhiDTO> GetChiPhiDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        void Create(ChiPhiDTO chiPhi);
        ChiPhiDTO Get(int maCP);
        void Update(ChiPhiDTO chiPhi);
        void Delete(int maCP);
    }
}
