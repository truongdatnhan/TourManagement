using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapper
{
    public class DiaDiemProfile : Profile
    {
        public DiaDiemProfile()
        {
            CreateMap<DiaDiemDTO, DiaDiem>();
            CreateMap<DiaDiem, DiaDiemDTO>();
        }
    }
}
