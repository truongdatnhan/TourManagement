using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface ITacGiaRepository : IEFRepository<TacGia>
    {
        int CountTacGia();

        IEnumerable<TacGia> LayTacGia();

        IEnumerable<TacGia> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}