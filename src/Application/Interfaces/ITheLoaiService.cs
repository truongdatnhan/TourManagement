using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITheLoaiService
    {
        IEnumerable<TheLoaiDTO> GetTheLoais(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);

        TheLoaiDTO GetTheLoai(int maTL);

        void ThemTheLoai(TheLoaiDTO theLoai);

        void SuaTheLoai(TheLoaiDTO theLoai);

        void XoaTheLoai(int maTL);
    }
}