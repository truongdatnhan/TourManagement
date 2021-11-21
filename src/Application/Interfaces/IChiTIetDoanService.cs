using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChiTietDoanService
    {
        IEnumerable<ChiTietDoanDTO> GetAll();
        bool Create(ChiTietDoanDTO dto);
        ChiTietDoanDTO Get(ChiTietDoanDTO dto);
        bool Update(ChiTietDoanDTO dto);
        bool Delete(ChiTietDoanDTO dto);
    }
}
