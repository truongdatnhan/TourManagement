using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class LoaiChiPhiProfile : Profile
    {
        public LoaiChiPhiProfile()
        {
            CreateMap<LoaiChiPhiDTO, LoaiChiPhi>();
            CreateMap<LoaiChiPhi, LoaiChiPhiDTO>();
        }
    }
}
