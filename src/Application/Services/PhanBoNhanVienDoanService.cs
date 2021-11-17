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

        public PhanBoNhanVienDoanDTO Get(int id)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(id);
            return mapper.Map<PhanBoNhanVienDoanDTO>(pb);
        }

        public bool Update(PhanBoNhanVienDoanDTO dto)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(dto.MaDoan);
            mapper.Map<PhanBoNhanVienDoanDTO, PhanBoNhanVienDoan>(dto, pb);
            phanBoNhanVienDoanRepository.Update(pb);
            return true;
        }

        public bool Delete(int id)
        {
            var pb = phanBoNhanVienDoanRepository.GetBy(id);
            phanBoNhanVienDoanRepository.Delete(pb);
            return true;
        }

        public IEnumerable<PhanBoNhanVienDoanDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PhanBoNhanVienDoanDTO>>(phanBoNhanVienDoanRepository.GetAll());
        }
    }
}
