using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILoaiChiPhiService : IService<LoaiChiPhiDTO>
    {
        IEnumerable<LoaiChiPhiDTO> GetDTOs();
    }
}
