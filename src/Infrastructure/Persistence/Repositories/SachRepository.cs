using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class SachRepository : EFRepository<Sach>, ISachRepository
    {
        public SachRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<Sach> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.Sachs.Include(s => s.TheLoai).Include(s => s.TacGia).Include(s => s.NhaXuatBan).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.TenSach.Contains(searchString) || s.TacGia.TenTG.Contains(searchString));
            }

            SortSachs(sortOrder, ref query);

            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortSachs(string sortOrder, ref IQueryable<Sach> query)
        {
            switch (sortOrder)
            {
                case "mas_desc":
                    query = query.OrderByDescending(s => s.MaSach);
                    break;

                case "mas":
                    query = query.OrderBy(s => s.MaSach);
                    break;

                case "tens_desc":
                    query = query.OrderByDescending(s => s.TenSach);
                    break;

                case "tens":
                    query = query.OrderBy(s => s.TenSach);
                    break;
            }
        }

        public int CountSach()
        {
            var c = context.Sachs.Count();
            return c;
        }
    }
}