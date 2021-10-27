using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Mappings
{
    public static class NhaXuatBanMapping
    {
        public static NhaXuatBanDTO MappingNhaXuatBanDto(this NhaXuatBan nhaXuatBan)
        {
            return new NhaXuatBanDTO
            {
                MaNXB = nhaXuatBan.MaNXB,
                TenNXB = nhaXuatBan.TenNXB
            };
        }

        public static NhaXuatBan MappingNhaXuatBan(this NhaXuatBanDTO nhaXuatBanDto)
        {
            return new NhaXuatBan
            {
                MaNXB = nhaXuatBanDto.MaNXB,
                TenNXB = nhaXuatBanDto.TenNXB
            };
        }

        public static void MappingNhaXuatBan(this NhaXuatBanDTO nhaXuatBanDto, NhaXuatBan nhaXuatBan)
        {
            nhaXuatBan.MaNXB = nhaXuatBanDto.MaNXB;
            nhaXuatBan.TenNXB = nhaXuatBanDto.TenNXB;
        }

        public static IEnumerable<NhaXuatBanDTO> MappingNhaXuatBanDtos(this IEnumerable<NhaXuatBan> nhaXuatBans)
        {
            foreach (var nhaXuatBan in nhaXuatBans)
            {
                yield return nhaXuatBan.MappingNhaXuatBanDto();
            }
        }
    }
}