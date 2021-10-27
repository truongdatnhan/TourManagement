using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISachRepository : IEFRepository<Sach>
    {
        int CountSach();

        IEnumerable<Sach> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}