using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPhieuPhatService
    {
        IEnumerable<PhieuPhatDTO> GetPhieuPhats(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        PhieuPhatDTO GetPhieuPhat(int maPP); 
        bool CreatePhieuPhat(PhieuPhatDTO phieuphat);
        void UpdatePhieuPhat(PhieuPhatDTO phieuphat);
        void DeletePhieuPhat(int maPP);
        bool AddCTPP(ChiTietPhieuPhatDTO ctppDTO);
        void UpdateCTPP(ChiTietPhieuPhatDTO ctppDTO);
        void DeleteCTPP(IEnumerable<ChiTietPhieuPhatDTO> ctppDTOList);
    }
}
