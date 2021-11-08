using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class KhachProfile : Profile
    {
        public KhachProfile()
        {
            CreateMap<KhachDTO, Khach>();
            CreateMap<Khach, KhachDTO>();
        }
    }
}
