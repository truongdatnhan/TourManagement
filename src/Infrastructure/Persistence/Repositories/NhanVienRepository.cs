using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Persistence.Repositories
{
    public class NhanVienRepository : EFRepository<AppUser>, INhanVienRepository
    {
        public NhanVienRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<AppUser> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = context.NhanViens.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(nv => nv.TenNV.Contains(searchString));
            }

            SortNhanViens(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortNhanViens(string sortOrder, ref IQueryable<AppUser> query)
        {
            switch (sortOrder)
            {
                case "idnv_desc":
                    query = query.OrderByDescending(nv => nv.Id);
                    break;
                case "idnv":
                    query = query.OrderBy(nv => nv.Id);
                    break;

                case "honv_desc":
                    query = query.OrderByDescending(nv => nv.HoNV);
                    break;
                case "honv":
                    query = query.OrderBy(nv => nv.HoNV);
                    break;

                case "tennv_desc":
                    query = query.OrderByDescending(nv => nv.TenNV);
                    break;
                case "tennv":
                    query = query.OrderBy(nv => nv.TenNV);
                    break;
                
                case "dobnv_desc":
                    query = query.OrderByDescending(nv => nv.DoBNV);
                    break;
                case "dobnv":
                    query = query.OrderBy(nv => nv.DoBNV);
                    break;

                case "sdtnv_desc":
                    query = query.OrderByDescending(nv => nv.PhoneNumber);
                    break;
                case "sdtnv":
                    query = query.OrderBy(nv => nv.PhoneNumber);
                    break;

                case "emailnv_desc":
                    query = query.OrderByDescending(nv => nv.Email);
                    break;
                case "emailnv":
                    query = query.OrderBy(nv => nv.Email);
                    break;
            }
        }
    }
}