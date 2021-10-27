using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class NhaXuatBanRepository : EFRepository<NhaXuatBan>, INhaXuatBanRepository
    {
        public NhaXuatBanRepository(QLTVContext context) : base(context)
        {
        }

        public IEnumerable<NhaXuatBan> LayNXB()
        {
            List<NhaXuatBan> nxb = new List<NhaXuatBan>();
            nxb = (from n in context.NhaXuatBans select n).ToList();
            nxb.Insert(0, new NhaXuatBan { MaNXB = 0, TenNXB = "Chọn nhà xuất bản" });
            return nxb;
        }

        public IEnumerable<NhaXuatBan> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.NhaXuatBans.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(nxb => nxb.TenNXB.Contains(searchString));
            }

            SortNhaXuatBans(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortNhaXuatBans(string sortOrder, ref IQueryable<NhaXuatBan> query)
        {
            switch (sortOrder)
            {
                case "manxb_desc":
                    query = query.OrderByDescending(nxb => nxb.MaNXB);
                    break;

                case "manxb":
                    query = query.OrderBy(nxb => nxb.MaNXB);
                    break;

                case "tennxb_desc":
                    query = query.OrderByDescending(nxb => nxb.TenNXB);
                    break;

                case "tennxb":
                    query = query.OrderBy(nxb => nxb.TenNXB);
                    break;
            }
        }

        public int CountNXB()
        {
            var c = context.NhaXuatBans.Count();
            return c;
        }
    }
}