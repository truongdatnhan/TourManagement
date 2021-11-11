using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDoanDuLichService : IService<DoanDuLichDTO>
    {
        bool CreateNDT(NoiDungTourDTO dto);
        NoiDungTourDTO GetNDT(int id);
        bool UpdateNDT(NoiDungTourDTO dto);
        bool DeleteNDT(int id);
        IEnumerable<KhachDTO> GetKhach_DTOs(int id);
    }
}
