using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class NoiDungTourProfile : Profile
    {
        public NoiDungTourProfile()
        {
            CreateMap<NoiDungTourDTO, NoiDungTour>();
            CreateMap<NoiDungTour, NoiDungTourDTO>();
        }
    }
}
