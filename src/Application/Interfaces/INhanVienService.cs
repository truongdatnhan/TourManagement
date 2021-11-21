using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface INhanVienService : IService<NhanVienDTO>
    {
        IEnumerable<NhanVienDTO> GetDTOs();
    }
}
