using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Persistence.Repositories
{
    public class ChiTietPhieuMuonRepository : EFRepository<ChiTietPhieuMuon>, IChiTietPhieuMuonRepository
    {
        public ChiTietPhieuMuonRepository(TourContext context) : base(context)
        {
        }

        public IEnumerable<ChiTietPhieuMuon> CTPMs(int maPM)
        {
            var query = context.ChiTietPhieuMuons.AsQueryable();

            if (!(maPM==0))
            {
                query = query.Where(ctpm => ctpm.MaPM == maPM);
            }

            /*SortPhieuMuons(sortOrder, ref query);
            count = query.Count();*/

            return query.ToList();
        }


        public ChiTietPhieuMuon GetBy(int maPM, int maSach)
        {
            return context.Set<ChiTietPhieuMuon>().Find(maPM, maSach);
        }
    }
}
