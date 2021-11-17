using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class PhanBoNhanVienDoanProfile : Profile
    {
        public PhanBoNhanVienDoanProfile()
        {
            CreateMap<PhanBoNhanVienDoanDTO, PhanBoNhanVienDoanDTO>();
            CreateMap<PhanBoNhanVienDoan, PhanBoNhanVienDoanDTO>();
        }
    }
}
