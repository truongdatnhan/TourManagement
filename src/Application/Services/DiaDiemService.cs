using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DiaDiemService : IDiaDiemService
    {
        private readonly IDiaDiemRepository diaDiemRepository;
        private readonly IMapper mapper;

        public DiaDiemService(IDiaDiemRepository diaDiemRepository, IMapper mapper)
        {
            this.diaDiemRepository = diaDiemRepository;
            this.mapper = mapper;
        }

        public bool Create(DiaDiemDTO dto)
        {
            var dd = mapper.Map<DiaDiem>(dto);
            diaDiemRepository.Add(dd);
            return true;
        }

        public DiaDiemDTO Get(int maDD)
        {
            var dd = diaDiemRepository.GetBy(maDD);
            return mapper.Map<DiaDiemDTO>(dd);
        }
        public bool Update(DiaDiemDTO dto)
        {
            var dd = diaDiemRepository.GetBy(dto.MaDiaDiem);
            mapper.Map<DiaDiemDTO, DiaDiem>(dto, dd);
            diaDiemRepository.Update(dd);
            return true;
        }

        public bool Delete(int maDD)
        {
            var dd = diaDiemRepository.GetBy(maDD);
            diaDiemRepository.Delete(dd);
            return true;
        }

        public IEnumerable<DiaDiemDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var dds = diaDiemRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<DiaDiemDTO>>(dds);
        }

        public IEnumerable<DiaDiemDTO> GetDTOs()
        {
            return mapper.Map<IEnumerable<DiaDiemDTO>>(diaDiemRepository.GetAll());
        }
    }
}
