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
    public class NoiDungTourService : INoiDungTourService
    {
        private readonly INoiDungTourRepository noiDungTourRepository;
        private readonly IMapper mapper;

        public NoiDungTourService(INoiDungTourRepository noiDungTourRepository, IMapper mapper)
        {
            this.noiDungTourRepository = noiDungTourRepository;
            this.mapper = mapper;
        }

        #region Nội Dung Tour

        public bool Create(NoiDungTourDTO dto)
        {
            var ndt = mapper.Map<NoiDungTour>(dto);
            noiDungTourRepository.Add(ndt);
            return true;
        }

        public NoiDungTourDTO Get(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            return mapper.Map<NoiDungTourDTO>(ndt);
        }

        public bool Update(NoiDungTourDTO dto)
        {
            var ndt = noiDungTourRepository.GetBy(dto.MaDoan);
            mapper.Map<NoiDungTourDTO, NoiDungTour>(dto, ndt);
            noiDungTourRepository.Update(ndt);
            return true;
        }

        public bool Delete(int id)
        {
            var ndt = noiDungTourRepository.GetBy(id);
            noiDungTourRepository.Delete(ndt);
            return true;
        }

        public IEnumerable<ChiPhiDTO> GetDTOs()
        {
            var chiPhis = noiDungTourRepository.GetAll();
            return mapper.Map<IEnumerable<ChiPhiDTO>>(chiPhis);
            throw new NotImplementedException();
        }

        public IEnumerable<ChiPhiDTO> GetDTOs_Tour(int maTour)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NoiDungTourDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
