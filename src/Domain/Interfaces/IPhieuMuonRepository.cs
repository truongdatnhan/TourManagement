using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IPhieuMuonRepository:IEFRepository<PhieuMuon>
    {
        IEnumerable<PhieuMuon> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}
