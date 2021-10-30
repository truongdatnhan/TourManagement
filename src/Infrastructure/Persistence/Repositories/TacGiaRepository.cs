using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class TacGiaRepository : EFRepository<TacGia>, ITacGiaRepository
    {
        public TacGiaRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<TacGia> LayTacGia()
        {
            List<TacGia> tg = new List<TacGia>();
            tg = (from t in context.TacGias select t).ToList();
            tg.Insert(0, new TacGia { MaTG = 0, TenTG = "Chọn tác giả" });
            return tg;
        }

        public IEnumerable<TacGia> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.TacGias.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(tg => tg.TenTG.Contains(searchString));
            }

            SortTacGias(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortTacGias(string sortOrder, ref IQueryable<TacGia> query)
        {
            switch (sortOrder)
            {
                case "matg_desc":
                    query = query.OrderByDescending(tg => tg.MaTG);
                    break;

                case "matg":
                    query = query.OrderBy(tg => tg.MaTG);
                    break;

                case "tentg_desc":
                    query = query.OrderByDescending(tg => tg.TenTG);
                    break;

                case "tentg":
                    query = query.OrderBy(tg => tg.TenTG);
                    break;
            }
        }

        public int CountTacGia()
        {
            var c = context.TacGias.Count();
            return c;
        }
    }
}