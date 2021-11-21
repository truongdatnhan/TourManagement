using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPhanBoNhanVienDoanService
    {
        IEnumerable<PhanBoNhanVienDoanDTO> GetAll();
        bool Create(PhanBoNhanVienDoanDTO dto);
        PhanBoNhanVienDoanDTO Get(PhanBoNhanVienDoanDTO dto);
        bool Update(PhanBoNhanVienDoanDTO dto);
        bool Delete(PhanBoNhanVienDoanDTO dto);
    }
}
