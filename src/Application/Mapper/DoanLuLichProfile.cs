using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class DoanDuLichProfile : Profile
    {
        public DoanDuLichProfile()
        {
            CreateMap<DoanDuLichDTO, DoanDuLich>();
            CreateMap<DoanDuLich, DoanDuLichDTO>();
        }
    }
}
