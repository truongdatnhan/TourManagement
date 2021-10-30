using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class ChiTietPhieuPhatRepository : EFRepository<ChiTietPhieuPhat>, IChiTietPhieuPhatRepository
    {
        public ChiTietPhieuPhatRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<ChiTietPhieuPhat> CTPPs(int maPP)
        {
            var query = context.ChiTietPhieuPhats.AsQueryable();

            if (!(maPP == 0))
            {
                query = query.Where(ctpp => ctpp.MaPP == maPP);
            }

            return query.ToList();
        }


        public ChiTietPhieuPhat GetBy(int maPP, int maSach)
        {
            return context.Set<ChiTietPhieuPhat>().Find(maPP, maSach);
        }
    }
}
