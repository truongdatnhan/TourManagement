using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface IPhieuMuonService
    {
        IEnumerable<PhieuMuonDTO> GetPhieuMuons(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        PhieuMuonDTO GetPhieuMuon(int maPM);
        bool CreatePhieuMuon(PhieuMuonDTO phieumuon);
        bool UpdatePhieuMuon(PhieuMuonDTO phieumuon);
        void DeletePhieuMuon(int maPM);
        bool AddCTPM(ChiTietPhieuMuonDTO ctpmDTO);
        void UpdateCTPM(ChiTietPhieuMuonDTO ctpmDTO);
        bool DeleteCTPM(IEnumerable<ChiTietPhieuMuonDTO> ctpmDTOList);
    }
}