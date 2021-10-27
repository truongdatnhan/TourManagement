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
    public class PhieuMuonService : IPhieuMuonService
    {
        private readonly IPhieuMuonRepository phieumuonRepository; //Lấy từ Domain
        private readonly IChiTietPhieuMuonRepository chiTietPhieuMuonRepository;
        private readonly ISachRepository sachRepository;
        private readonly IDocGiaRepository docGiaRepository;

        public PhieuMuonService(IPhieuMuonRepository phieuMuonRepository, IChiTietPhieuMuonRepository chiTietPhieuMuonRepository, ISachRepository sachRepository, IDocGiaRepository docGiaRepository)
        {
            this.phieumuonRepository = phieuMuonRepository;
            this.chiTietPhieuMuonRepository = chiTietPhieuMuonRepository;
            this.sachRepository = sachRepository;
            this.docGiaRepository = docGiaRepository;
        }

        public bool AddCTPM(ChiTietPhieuMuonDTO ctpmDTO)
        {
            var ctpm = ctpmDTO.MappingCTPM();
            var pm = phieumuonRepository.GetBy(ctpm.MaPM);
            if(pm.TrangThai == 0)
            {
                return false;
            }
            var sach = sachRepository.GetBy(ctpmDTO.MaSach);
            if (sach == null)
            {
                return false;
            }
            if (sach.TrangThaiSach.Equals("Đã mượn"))
            {
                return false;
            }
            if(chiTietPhieuMuonRepository.CTPMs(ctpm.MaPM).Any( c => c.MaSach.Equals(ctpm.MaSach)) )
            {
                return false;
            }

            sach.TrangThaiSach = "Đã mượn";
            sachRepository.Update(sach);
            ctpm.PhiMuon = (int)(sach.GiaBia * 0.2);
            ctpm.TrangThai = 1;
            pm.TongPhiMuon += ctpm.PhiMuon;
            phieumuonRepository.Update(pm);
            chiTietPhieuMuonRepository.Add(ctpm);
            return true;
        }

        public bool DeleteCTPM(IEnumerable<ChiTietPhieuMuonDTO> ctpmDTOList)
        {
            var list = ctpmDTOList.Where(c => c.IsSelected == true);
            if( !list.Any())
            {
                return false;
            }
            list.ToList().ForEach(c =>
            {
                var ctpm = chiTietPhieuMuonRepository.GetBy(c.MaPM, c.MaSach);
                var sach = sachRepository.GetBy(c.MaSach);
                sach.TrangThaiSach = "Còn";
                sachRepository.Update(sach);
                ctpm.TrangThai = 0;
                chiTietPhieuMuonRepository.Update(ctpm);
            });
            return true;
        }

        public void UpdateCTPM(ChiTietPhieuMuonDTO ctpmDTO)
        {
            var ctpm = chiTietPhieuMuonRepository.GetBy(ctpmDTO.MaPM, ctpmDTO.MaSach);
            ctpmDTO.MappingCTPM(ctpm);
            chiTietPhieuMuonRepository.Update(ctpm);
        }

        public bool CreatePhieuMuon(PhieuMuonDTO phieumuonDTO)
        {
            var docgia = docGiaRepository.GetBy(phieumuonDTO.MaDG);
            if(docgia == null)
            {
                return false;
            }
            var phieumuon = phieumuonDTO.MappingPhieuMuon();
            phieumuon.TongPhiMuon = 0;
            phieumuon.TrangThai = 1;
            phieumuonRepository.Add(phieumuon);
            return true;
        }
        public bool UpdatePhieuMuon(PhieuMuonDTO phieumuonDTO)
        {
            var phieumuon = phieumuonRepository.GetBy(phieumuonDTO.MaPM);
            if(phieumuon.TrangThai == 0)
            {
                return false;
            }
            var list = chiTietPhieuMuonRepository.CTPMs(phieumuon.MaPM);

            if( !list.Any() )
            {
                phieumuonRepository.Delete(phieumuon);
                return true;
            }

            list = list.Where(x => x.TrangThai == 1);

            if (list == null)
            {
                phieumuon.TrangThai = 0;
                phieumuonRepository.Update(phieumuon);
                return true;
            }
            list.ToList().ForEach(x =>
            {
                var sach = sachRepository.GetBy(x.MaSach);
                sach.TrangThaiSach = "Còn";
                sachRepository.Update(sach);
                x.TrangThai = 0;
                chiTietPhieuMuonRepository.Update(x);
            });
            phieumuon.TrangThai = 0;
            phieumuonRepository.Update(phieumuon);
            return true;
        }

        public void DeletePhieuMuon(int maPM)
        {
            var phieumuon = phieumuonRepository.GetBy(maPM);
            phieumuonRepository.Delete(phieumuon);
        }

        public PhieuMuonDTO GetPhieuMuon(int maPM)
        {
            var phieumuon = phieumuonRepository.GetBy(maPM);
            var ctpms = chiTietPhieuMuonRepository.CTPMs(phieumuon.MaPM);
            if (ctpms.Any())
            {
                phieumuon.ChiTietPhieuMuons = (List<ChiTietPhieuMuon>)ctpms;
            }

            return phieumuon.MappingDTO();
        }

        public IEnumerable<PhieuMuonDTO> GetPhieuMuons(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var phieuMuons = phieumuonRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            foreach(PhieuMuon pm in phieuMuons)
            {
                var ctpms = chiTietPhieuMuonRepository.CTPMs(pm.MaPM);
                if(ctpms.Any())
                {
                    pm.ChiTietPhieuMuons = (List<ChiTietPhieuMuon>)ctpms;
                }
            }
            return phieuMuons.MappingDtos();
        }
    }
}
