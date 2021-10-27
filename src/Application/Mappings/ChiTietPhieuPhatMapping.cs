using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class ChiTietPhieuPhatMapping
    {
        public static ChiTietPhieuPhatDTO MappingDTO(this ChiTietPhieuPhat ctpp)
        {
            return new ChiTietPhieuPhatDTO
            {
                MaPP = ctpp.MaPP,
                MaSach = ctpp.MaSach,
                NoiDungViPham = ctpp.NoiDungViPham,
                XuLyViPham = ctpp.XuLyViPham,
                PhiPhat = ctpp.PhiPhat
            };
        }

        public static ChiTietPhieuPhat MappingCTPP(this ChiTietPhieuPhatDTO ctppDTO)
        {
            return new ChiTietPhieuPhat
            {
                MaPP = ctppDTO.MaPP,
                MaSach = ctppDTO.MaSach,
                NoiDungViPham = ctppDTO.NoiDungViPham,
                XuLyViPham = ctppDTO.XuLyViPham,
                PhiPhat = ctppDTO.PhiPhat
            };
        }
        public static void MappingCTPP(this ChiTietPhieuPhatDTO ctppDTO, ChiTietPhieuPhat ctpp)
        {
            ctpp.MaPP = ctppDTO.MaPP;
            ctpp.MaSach = ctppDTO.MaSach;
            ctpp.NoiDungViPham = ctppDTO.NoiDungViPham;
            ctpp.XuLyViPham = ctppDTO.XuLyViPham;
            ctpp.PhiPhat = ctppDTO.PhiPhat;
        }
        public static IEnumerable<ChiTietPhieuPhatDTO> MappingDtos(this IEnumerable<ChiTietPhieuPhat> DSCTPP)
        {
            foreach (var ctpp in DSCTPP)
            {
                yield return ctpp.MappingDTO();
            }
        }

        public static IEnumerable<ChiTietPhieuPhat> MappingCTPPs(this IEnumerable<ChiTietPhieuPhatDTO> DSCTPPDTO)
        {
            foreach (var ctppDTO in DSCTPPDTO)
            {
                yield return ctppDTO.MappingCTPP();
            }
        }
    }
}
