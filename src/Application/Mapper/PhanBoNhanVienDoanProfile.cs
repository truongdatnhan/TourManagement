using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class PhanBoNhanVienDoanProfile : Profile
    {
        public PhanBoNhanVienDoanProfile()
        {
            CreateMap<PhanBoNhanVienDoanDTO, PhanBoNhanVienDoan>();
            CreateMap<PhanBoNhanVienDoan, PhanBoNhanVienDoanDTO>();
        }
    }
}
