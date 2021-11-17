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
    public class ChiTietDoanService : IChiTietDoanService
    {
        private readonly IChiTietDoanRepository chiTietDoanRepository;
        private readonly IMapper mapper;

        public ChiTietDoanService(IChiTietDoanRepository chiTietDoanRepository, IMapper mapper)
        {
            this.chiTietDoanRepository = chiTietDoanRepository;
            this.mapper = mapper;
        }

        public bool Create(ChiTietDoanDTO dto)
        {
            var ctd = mapper.Map<ChiTietDoan>(dto);
            chiTietDoanRepository.Add(ctd);
            return true;
        }

        public ChiTietDoanDTO Get(int id)
        {
            var ctd = chiTietDoanRepository.GetBy(id);
            return mapper.Map<ChiTietDoanDTO>(ctd);
        }

        public bool Update(ChiTietDoanDTO dto)
        {
            var ctd = chiTietDoanRepository.GetBy(dto.MaDoan);
            mapper.Map<ChiTietDoanDTO, ChiTietDoan>(dto, ctd);
            chiTietDoanRepository.Update(ctd);
            return true;
        }

        public bool Delete(int id)
        {
            var ctd = chiTietDoanRepository.GetBy(id);
            chiTietDoanRepository.Delete(ctd);
            return true;
        }

        public IEnumerable<ChiTietDoanDTO> GetAll()
        {
            return mapper.Map<IEnumerable<ChiTietDoanDTO>>(chiTietDoanRepository.GetAll());
        }


    }
}
