using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class ChiTietPhieuMuonMapping
    {
        public static ChiTietPhieuMuonDTO MappingDTO(this ChiTietPhieuMuon ctpm)
        {
            return new ChiTietPhieuMuonDTO
            {
                MaPM = ctpm.MaPM,
                MaSach = ctpm.MaSach,
                PhiMuon = ctpm.PhiMuon,
                NgayHetHan = ctpm.NgayHetHan,
                GiaHan = ctpm.GiaHan,
                TrangThai = ctpm.TrangThai
            };
        }

        public static ChiTietPhieuMuon MappingCTPM(this ChiTietPhieuMuonDTO ctpmDTO)
        {
            return new ChiTietPhieuMuon
            {
                MaPM = ctpmDTO.MaPM,
                MaSach = ctpmDTO.MaSach,
                PhiMuon = ctpmDTO.PhiMuon,
                NgayHetHan = ctpmDTO.NgayHetHan,
                GiaHan = ctpmDTO.GiaHan,
                TrangThai = ctpmDTO.TrangThai
            };
        }
        public static void MappingCTPM(this ChiTietPhieuMuonDTO ctpmDTO, ChiTietPhieuMuon ctpm)
        {
            ctpm.MaPM = ctpmDTO.MaPM;
            ctpm.MaSach = ctpmDTO.MaSach;
            ctpm.PhiMuon = ctpmDTO.PhiMuon;
            ctpm.NgayHetHan = ctpmDTO.NgayHetHan;
            ctpm.GiaHan = ctpmDTO.GiaHan;
            ctpm.TrangThai = ctpmDTO.TrangThai;
        }
        public static IEnumerable<ChiTietPhieuMuonDTO> MappingDtos(this IEnumerable<ChiTietPhieuMuon> DSCTPM)
        {
            foreach (var ctpm in DSCTPM)
            {
                yield return ctpm.MappingDTO();
            }
        }

        public static IEnumerable<ChiTietPhieuMuon> MappingCTPMs(this IEnumerable<ChiTietPhieuMuonDTO> DSCTPMDTO)
        {
            foreach (var ctpmDTO in DSCTPMDTO)
            {
                yield return ctpmDTO.MappingCTPM();
            }
        }
    }
}
