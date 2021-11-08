using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class GiaTourProfile : Profile
    {
        public GiaTourProfile()
        {
            CreateMap<GiaTourDTO, GiaTour>();
            CreateMap<GiaTour, GiaTourDTO>();
        }
    }
}
