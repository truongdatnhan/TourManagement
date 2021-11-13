using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IChiTIetDoanService 
    {
        IEnumerable<ChiTietDoanDTO> GetAll();
        bool Create(ChiTietDoanDTO dto);
        ChiTietDoanDTO Get(int id);
        bool Update(ChiTietDoanDTO dto);
        bool Delete(int id);
    }
}
