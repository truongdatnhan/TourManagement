using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface IDocGiaRepository : IEFRepository<DocGia>
    {
        int CountDocGia();

        IEnumerable<DocGia> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}