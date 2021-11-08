using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class DiemThamQuanProfile : Profile
    {
        public DiemThamQuanProfile()
        {
            CreateMap<DiemThamQuanDTO, DiemThamQuan>();
            CreateMap<DiemThamQuan, DiemThamQuanDTO>();
        }
    }
}
