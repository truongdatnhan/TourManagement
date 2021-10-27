using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IChiTietPhieuPhatRepository : IEFRepository<ChiTietPhieuPhat>
    {
        IEnumerable<ChiTietPhieuPhat> CTPPs(int maPP);
        ChiTietPhieuPhat GetBy(int maPP, int maSach);
    }
}
