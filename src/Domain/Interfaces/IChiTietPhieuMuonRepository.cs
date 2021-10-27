using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IChiTietPhieuMuonRepository : IEFRepository<ChiTietPhieuMuon>
    {
        IEnumerable<ChiTietPhieuMuon> CTPMs(int maPM);
        ChiTietPhieuMuon GetBy(int maPM, int maSach);
    }
}
