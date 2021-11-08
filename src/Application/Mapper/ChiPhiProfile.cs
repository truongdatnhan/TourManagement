using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ChiPhiProfile : Profile
    {
        public ChiPhiProfile()
        {
            CreateMap<ChiPhiDTO, ChiPhi>();
            CreateMap<ChiPhi, ChiPhiDTO>();
        }
    }
}
