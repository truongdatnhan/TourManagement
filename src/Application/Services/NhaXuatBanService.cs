using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public class NhaXuatBanService : INhaXuatBanService
    {
        private readonly INhaXuatBanRepository _nhaXuatBanRepository; //Lấy từ Domain

        public NhaXuatBanService(INhaXuatBanRepository nhaXuatBanRepository)
        {
            _nhaXuatBanRepository = nhaXuatBanRepository;
        }

        public IEnumerable<NhaXuatBanDTO> GetNhaXuatBans(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var nhaXuatBans = _nhaXuatBanRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return nhaXuatBans.MappingNhaXuatBanDtos();
        }

        public NhaXuatBanDTO GetNhaXuatBan(int maNXB)
        {
            var nhaxuatban = _nhaXuatBanRepository.GetBy(maNXB);

            return nhaxuatban.MappingNhaXuatBanDto();
        }

        public void SuaNhaXuatBan(NhaXuatBanDTO nhaXuatBanDto)
        {
            var nhaXuatBan = _nhaXuatBanRepository.GetBy(nhaXuatBanDto.MaNXB);

            nhaXuatBanDto.MappingNhaXuatBan(nhaXuatBan);

            _nhaXuatBanRepository.Update(nhaXuatBan);
        }

        public void ThemNhaXuatBan(NhaXuatBanDTO nhaXuatBanDto)
        {
            var nhaXuatBan = nhaXuatBanDto.MappingNhaXuatBan();

            _nhaXuatBanRepository.Add(nhaXuatBan);
        }

        public void XoaNhaXuatBan(int maNXB)
        {
            var nhaXuatBan = _nhaXuatBanRepository.GetBy(maNXB);

            _nhaXuatBanRepository.Delete(nhaXuatBan);
        }
    }
}