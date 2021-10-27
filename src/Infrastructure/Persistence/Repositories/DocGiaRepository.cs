using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class DocGiaRepository : EFRepository<DocGia>, IDocGiaRepository
    {
        public DocGiaRepository(QLTVContext context) : base(context)
        {
        }

        public IEnumerable<DocGia> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.DocGias.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(dg => dg.TenDG.Contains(searchString));
            }

            SortDocGias(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortDocGias(string sortOrder, ref IQueryable<DocGia> query)
        {
            switch (sortOrder)
            {
                case "tentl_desc":
                    query = query.OrderByDescending(dg => dg.TenDG);
                    break;

                case "tentl":
                    query = query.OrderBy(tg => tg.TenDG);
                    break;
            }
        }

        public int CountDocGia()
        {
            var c = context.DocGias.Count();
            return c;
        }
    }
}