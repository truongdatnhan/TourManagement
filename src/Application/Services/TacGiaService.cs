using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;
using System.Collections.Generic;

namespace Application.Services
{
    public class TacGiaService : ITacGiaService
    {
        private readonly ITacGiaRepository _tacGiaRepository; //Lấy từ Domain

        public TacGiaService(ITacGiaRepository tacGiaRepository)
        {
            _tacGiaRepository = tacGiaRepository;
        }

        public IEnumerable<TacGiaDTO> GetTacGias(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var tacGias = _tacGiaRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return tacGias.MappingTacGiaDtos();
        }

        public TacGiaDTO GetTacGia(int maTG)
        {
            var tacgia = _tacGiaRepository.GetBy(maTG);

            return tacgia.MappingTacGiaDto();
        }

        public void SuaTacGia(TacGiaDTO tacGiaDto)
        {
            var tacGia = _tacGiaRepository.GetBy(tacGiaDto.MaTG);

            tacGiaDto.MappingTacGia(tacGia);

            _tacGiaRepository.Update(tacGia);
        }

        public void ThemTacGia(TacGiaDTO tacGiaDto)
        {
            var tacGia = tacGiaDto.MappingTacGia();

            _tacGiaRepository.Add(tacGia);
        }

        public void XoaTacGia(int maTG)
        {
            var tacGia = _tacGiaRepository.GetBy(maTG);

            _tacGiaRepository.Delete(tacGia);
        }
    }
}