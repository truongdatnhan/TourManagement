using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface INhanVienRepository : IEFRepository<AppUser>
    {
        IEnumerable<AppUser> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
    }
}
