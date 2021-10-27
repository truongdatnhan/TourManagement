using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class PhieuPhatService : IPhieuPhatService
    {
        private readonly IPhieuPhatRepository phieuphatRepository;
        private readonly IChiTietPhieuPhatRepository chiTietPhieuPhatRepository;
        private readonly ISachRepository sachRepository;
        private readonly IDocGiaRepository docGiaRepository;

        public PhieuPhatService(IPhieuPhatRepository phieuPhatRepository, IChiTietPhieuPhatRepository chiTietPhieuPhatRepository, ISachRepository sachRepository, IDocGiaRepository docGiaRepository)
        {
            this.phieuphatRepository = phieuPhatRepository;
            this.chiTietPhieuPhatRepository = chiTietPhieuPhatRepository;
            this.sachRepository = sachRepository;
            this.docGiaRepository = docGiaRepository;
        }

        public bool AddCTPP(ChiTietPhieuPhatDTO ctppDTO)
        {
            var ctpp = ctppDTO.MappingCTPP();
            var sach = sachRepository.GetBy(ctppDTO.MaSach);
            if (sach == null)
            {
                return false;
            }
            var phieuphat = phieuphatRepository.GetBy(ctppDTO.MaPP);
            if (chiTietPhieuPhatRepository.CTPPs(ctpp.MaPP).Any(c => c.MaSach.Equals(ctpp.MaSach)))
            {
                return false;
            }
            if (phieuphat.TrangThai == 0)
            {
                return false;
            }
            if(ctpp.NoiDungViPham == "Trễ hạn sách")
            {
                ctpp.PhiPhat += (int)(sach.GiaBia *0.2); 
            }
            if (ctpp.NoiDungViPham == "Hư sách")
            {
                ctpp.PhiPhat += (int)(sach.GiaBia * 0.3);
            }
            if (ctpp.NoiDungViPham == "Mất sách")
            {
                ctpp.PhiPhat += (int)(sach.GiaBia * 1.2);
            }
            
            phieuphat.TongPhiPhat += ctpp.PhiPhat;
            
            
            chiTietPhieuPhatRepository.Add(ctpp);
            phieuphatRepository.Update(phieuphat);
            return true;
        }

        public void DeleteCTPP(IEnumerable<ChiTietPhieuPhatDTO> ctppDTOList)
        {
            var list = ctppDTOList.Where(c => c.IsSelected == true);

            list.ToList().ForEach(c =>
            {
                var ctpp = chiTietPhieuPhatRepository.GetBy(c.MaPP, c.MaSach);

                chiTietPhieuPhatRepository.Delete(ctpp);
            });

        }

        public void UpdateCTPP(ChiTietPhieuPhatDTO ctppDTO)
        {
            var ctpp = chiTietPhieuPhatRepository.GetBy(ctppDTO.MaPP, ctppDTO.MaSach);
            
            ctppDTO.MappingCTPP(ctpp);
            chiTietPhieuPhatRepository.Update(ctpp);
        }
        public bool CreatePhieuPhat(PhieuPhatDTO phieuphatDTO)
        {
            var docgia = docGiaRepository.GetBy(phieuphatDTO.MaDG);
            if(docgia == null)
            {
                return false;
            }
            var phieuphat = phieuphatDTO.MappingPhieuPhat();
            phieuphat.TongPhiPhat = 0;
            phieuphat.TrangThai = 1;
            phieuphatRepository.Add(phieuphat);
            return true;
        }
        public void DeletePhieuPhat(int maPP)
        {
            var phieuphat = phieuphatRepository.GetBy(maPP);
            phieuphat.TrangThai = 0;

            phieuphatRepository.Update(phieuphat);

        }

        public PhieuPhatDTO GetPhieuPhat(int maPP)
        {
            var phieuphat = phieuphatRepository.GetBy(maPP);
            var ctpps = chiTietPhieuPhatRepository.CTPPs(phieuphat.MaPP);
            if (ctpps.Any())
            {
                phieuphat.ChiTietPhieuPhats = (List<ChiTietPhieuPhat>)ctpps;
            }

            return phieuphat.MappingDTO();
        }

        public IEnumerable<PhieuPhatDTO> GetPhieuPhats(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var phieuPhats = phieuphatRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            foreach (PhieuPhat pp in phieuPhats)
            {
                var ctpps = chiTietPhieuPhatRepository.CTPPs(pp.MaPP);
                if (ctpps.Any())
                {
                    pp.ChiTietPhieuPhats = (List<ChiTietPhieuPhat>)ctpps;
                }
            }
            return phieuPhats.MappingDtos();
        }

        public void UpdatePhieuPhat(PhieuPhatDTO phieuphatDTO)
        {
            var phieuphat = phieuphatRepository.GetBy(phieuphatDTO.MaPP);
            phieuphat.TrangThai = 0;
            phieuphatRepository.Update(phieuphat);
        }
    }
}
