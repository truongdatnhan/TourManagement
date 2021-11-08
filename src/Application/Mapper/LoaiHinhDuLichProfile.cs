using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class LoaiHinhDuLichProfile : Profile
    {
        public LoaiHinhDuLichProfile()
        {
            CreateMap<LoaiHinhDuLichDTO, LoaiHinhDuLich>();
            CreateMap<LoaiHinhDuLich, LoaiHinhDuLichDTO>();
        }
    }
}
