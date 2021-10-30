using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class PhieuMuonRepository : EFRepository<PhieuMuon>, IPhieuMuonRepository
    {
        public PhieuMuonRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<PhieuMuon> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.PhieuMuons.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(pm => pm.MaPM == Int32.Parse(searchString));
            }

            SortPhieuMuons(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortPhieuMuons(string sortOrder, ref IQueryable<PhieuMuon> query)
        {
            /*switch (sortOrder)
            {
                case "tentl_desc":
                    query = query.OrderByDescending(dg => dg.TenDG);
                    break;

                case "tentl":
                    query = query.OrderBy(tg => tg.TenDG);
                    break;
            }*/
        }
    }
}
