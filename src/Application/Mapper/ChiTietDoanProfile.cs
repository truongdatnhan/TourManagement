using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class ChiTietDoanProfile : Profile
    {
        public ChiTietDoanProfile()
        {
            CreateMap<ChiTietDoanDTO, ChiTietDoan>();
            CreateMap<ChiTietDoan, ChiTietDoanDTO>();
        }
    }
}
