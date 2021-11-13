using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IChiPhiService : IService<ChiPhiDTO>
    {
        IEnumerable<ChiPhiDTO> GetDTOs_Tour(int maTour);
    }
}
