using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ILoaiHinhDuLichService : IService<LoaiHinhDuLichDTO>
    {
        IEnumerable<LoaiHinhDuLichDTO> GetDTOs();
    }
}
