using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDiemThamQuanService 
    {
        IEnumerable<DiemThamQuanDTO> GetAll();
        bool Create(DiemThamQuanDTO dto);
        DiemThamQuanDTO Get(int id);
        bool Update(DiemThamQuanDTO dto);
        bool Delete(DiemThamQuanDTO dto);
    }
}
