using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class NhanVienProfile : Profile
    {
        public NhanVienProfile()
        {
            CreateMap<NhanVienDTO, NhanVien>();
            CreateMap<NhanVien, NhanVienDTO>();
        }
    }
}
