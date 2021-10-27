using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TheLoaiService : ITheLoaiService
    {
        private readonly ITheLoaiRepository _theLoaiRepository; //Lấy từ Domain

        public TheLoaiService(ITheLoaiRepository theLoaiRepository)
        {
            _theLoaiRepository = theLoaiRepository;
        }

        public IEnumerable<TheLoaiDTO> GetTheLoais(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var theLoais = _theLoaiRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return theLoais.MappingTheLoaiDtos();
        }

        public TheLoaiDTO GetTheLoai(int maTL)
        {
            var theloai = _theLoaiRepository.GetBy(maTL);

            return theloai.MappingTheLoaiDto();
        }

        public void SuaTheLoai(TheLoaiDTO theLoaiDto)
        {
            var theLoai = _theLoaiRepository.GetBy(theLoaiDto.MaTL);

            theLoaiDto.MappingTheLoai(theLoai);

            _theLoaiRepository.Update(theLoai);
        }

        public void ThemTheLoai(TheLoaiDTO theLoaiDto)
        {
            var theLoai = theLoaiDto.MappingTheLoai();

            _theLoaiRepository.Add(theLoai);
        }

        public void XoaTheLoai(int maTL)
        {
            var theLoai = _theLoaiRepository.GetBy(maTL);

            _theLoaiRepository.Delete(theLoai);
        }
    }
}