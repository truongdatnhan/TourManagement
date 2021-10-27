using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class SachService : ISachService
    {
        private readonly ISachRepository _sachRepository; //Lấy từ Domain

        public SachService(ISachRepository sachRepository)
        {
            _sachRepository = sachRepository;
        }

        public IEnumerable<SachDTO> GetSachs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var sachs = _sachRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return sachs.MappingSachDtos();
        }

        public SachDTO GetSach(int maS)
        {
            var sach = _sachRepository.GetBy(maS);
            return sach.MappingSachDto();
        }

        public bool SuaSach(SachDTO sachDto)
        {
            if (sachDto.MaTL == 0 || sachDto.MaTG == 0 || sachDto.MaNXB == 0 || sachDto.Khu == 0 || sachDto.Tang == 0 || sachDto.Ke == 0)
            {
                return false;
            }

            var sach = _sachRepository.GetBy(sachDto.MaSach);
            sachDto.MappingSach(sach);
            _sachRepository.Update(sach);
            return true;
        }

        public bool ThemSach(SachDTO sachDto)
        {

            if( sachDto.MaTL == 0 || sachDto.MaTG == 0 || sachDto.MaNXB == 0 || sachDto.Khu == 0 || sachDto.Tang == 0 || sachDto.Ke == 0 )
            {
                return false;
            }

            var sach = sachDto.MappingSach();
            sach.TrangThaiSach = "Còn";
            _sachRepository.Add(sach);
            return true;
        }

        public void XoaSach(int maS)
        {
            var sach = _sachRepository.GetBy(maS);
            _sachRepository.Delete(sach);
        }
    }
}