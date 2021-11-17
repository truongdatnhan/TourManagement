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
    public class DiemThamQuanService : IDiemThamQuanService 
    { 
        private readonly IDiemThamQuanRepository diemThamQuanRepository;
        private readonly IMapper mapper;

        public DiemThamQuanService(IDiemThamQuanRepository diemThamQuanRepository, IMapper mapper)
        {
            this.diemThamQuanRepository = diemThamQuanRepository;
            this.mapper = mapper;
        }

        public bool Create(DiemThamQuanDTO dto)
        {
            var dtq = mapper.Map<DiemThamQuan>(dto);
            diemThamQuanRepository.Add(dtq);
            return true;
        }

        public DiemThamQuanDTO Get(int id)
        {
            var dtq = diemThamQuanRepository.GetBy(id);
            return mapper.Map<DiemThamQuanDTO>(dtq);
        }

        public bool Update(DiemThamQuanDTO dto)
        {
            var dtq = diemThamQuanRepository.GetBy(dto.MaTour);
            mapper.Map<DiemThamQuanDTO, DiemThamQuan>(dto, dtq);
            diemThamQuanRepository.Update(dtq);
            return true;
        }

        public bool Delete(int id)
        {
            var dtq = diemThamQuanRepository.GetBy(id);
            diemThamQuanRepository.Delete(dtq);
            return true;
        }

        public IEnumerable<DiemThamQuanDTO> GetAll()
        {
            return mapper.Map<IEnumerable<DiemThamQuanDTO>>(diemThamQuanRepository.GetAll());
        }
    }
}
