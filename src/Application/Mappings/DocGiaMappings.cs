using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class DocGiaMappings
    {
        public static DocGiaDTO MappingDTO(this DocGia docgia)
        {
            return new DocGiaDTO
            {
                MaDG = docgia.MaDG,
                HoDG = docgia.HoDG,
                TenDG = docgia.TenDG,
                DoBDG = docgia.DoBDG,
                EmailDG = docgia.EmailDG,
                DiaChiDG = docgia.DiaChiDG,
                NgayDK = docgia.NgayDK,
                NgayHetHanDK = docgia.NgayHetHanDK
            };
        }

        public static DocGia MappingDocGia(this DocGiaDTO docgiaDTO)
        {
            return new DocGia
            {
                MaDG = docgiaDTO.MaDG,
                HoDG = docgiaDTO.HoDG,
                TenDG = docgiaDTO.TenDG,
                DoBDG = docgiaDTO.DoBDG,
                EmailDG = docgiaDTO.EmailDG,
                DiaChiDG = docgiaDTO.DiaChiDG,
                NgayDK = docgiaDTO.NgayDK,
                NgayHetHanDK = docgiaDTO.NgayHetHanDK
            };
        }
        public static void MappingDocGia(this DocGiaDTO docgiaDTO, DocGia docgia)
        {
            docgia.MaDG = docgiaDTO.MaDG;
            docgia.HoDG = docgiaDTO.HoDG;
            docgia.TenDG = docgiaDTO.TenDG;
            docgia.DoBDG = docgiaDTO.DoBDG;
            docgia.EmailDG = docgiaDTO.EmailDG;
            docgia.DiaChiDG = docgiaDTO.DiaChiDG;
            docgia.NgayDK = docgiaDTO.NgayDK;
            docgia.NgayHetHanDK = docgiaDTO.NgayHetHanDK;
        }
        public static IEnumerable<DocGiaDTO> MappingDtos(this IEnumerable<DocGia> DSDocGia)
        {
            foreach (var docgia in DSDocGia)
            {
                yield return docgia.MappingDTO();
            }
        }
    }
}
