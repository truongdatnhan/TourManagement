using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class PhanBoNhanVienDoanService : IPhanBoNhanVienDoanService
    {
        private readonly IPhanBoNhanVienDoanRepository phanBoNhanVienDoanRepository;
        private readonly IMapper mapper;

        public PhanBoNhanVienDoanService(IPhanBoNhanVienDoanRepository phanBoNhanVienDoanRepository, IMapper mapper)
        {
            this.phanBoNhanVienDoanRepository = phanBoNhanVienDoanRepository;
            this.mapper = mapper;
        }

        public bool Create(PhanBoNhanVienDoanDTO dto)
        {
            var pb = mapper.Map<PhanBoNhanVienDoan>(dto);
            phanBoNhanVienDoanRepository.Add(pb);
            return true;
        }

        public PhanBoNhanVienDoanDTO Get(PhanBoNhanVienDoanDTO dto)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(dto.MaDoan, dto.MaNhanVien);
            return mapper.Map<PhanBoNhanVienDoanDTO>(pb);
        }

        public bool Update(PhanBoNhanVienDoanDTO dto)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(dto.MaDoan, dto.MaNhanVien);
            mapper.Map<PhanBoNhanVienDoanDTO, PhanBoNhanVienDoan>(dto, pb);
            phanBoNhanVienDoanRepository.Update(pb);
            return true;
        }

        public bool Delete(PhanBoNhanVienDoanDTO dto)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(dto.MaDoan, dto.MaNhanVien);
            phanBoNhanVienDoanRepository.Delete(pb);
            return true;
        }

        public IEnumerable<PhanBoNhanVienDoanDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PhanBoNhanVienDoanDTO>>(phanBoNhanVienDoanRepository.GetAll());
        }
    }
}
