using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class TourDuLichProfile : Profile
    {
        public TourDuLichProfile()
        {
            CreateMap<TourDuLichDTO, TourDuLich>();
            CreateMap<TourDuLich, TourDuLichDTO>();
        }
    }
}
