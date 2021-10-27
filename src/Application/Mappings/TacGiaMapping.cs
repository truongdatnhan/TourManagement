using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class TacGiaMapping
    {
        public static TacGiaDTO MappingTacGiaDto(this TacGia tacGia)
        {
            return new TacGiaDTO
            {
                MaTG = tacGia.MaTG,
                TenTG = tacGia.TenTG
            };
        }

        public static TacGia MappingTacGia(this TacGiaDTO tacGiaDto)
        {
            return new TacGia
            {
                MaTG = tacGiaDto.MaTG,
                TenTG = tacGiaDto.TenTG
            };
        }

        public static void MappingTacGia(this TacGiaDTO tacGiaDto, TacGia tacGia)
        {
            tacGia.MaTG = tacGiaDto.MaTG;
            tacGia.TenTG = tacGiaDto.TenTG;
        }

        public static IEnumerable<TacGiaDTO> MappingTacGiaDtos(this IEnumerable<TacGia> tacGias)
        {
            foreach (var tacGia in tacGias)
            {
                yield return tacGia.MappingTacGiaDto();
            }
        }
    }
}