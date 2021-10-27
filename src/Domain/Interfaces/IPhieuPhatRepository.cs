using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface  IPhieuPhatRepository : IEFRepository<PhieuPhat>
    {
        IEnumerable<PhieuPhat> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}
