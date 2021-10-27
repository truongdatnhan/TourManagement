using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class PhieuPhatRepository : EFRepository<PhieuPhat>, IPhieuPhatRepository
    {
        public PhieuPhatRepository(QLTVContext context) : base(context)
        {
        }

        public IEnumerable<PhieuPhat> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.PhieuPhats.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(pp => pp.MaPP == Int32.Parse(searchString));
            }

            SortPhieuPhats(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortPhieuPhats(string sortOrder, ref IQueryable<PhieuPhat> query)
        {
        }
    }
}
