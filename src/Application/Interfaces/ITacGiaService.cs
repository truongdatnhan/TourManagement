using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface ITacGiaService
    {
        IEnumerable<TacGiaDTO> GetTacGias(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);

        TacGiaDTO GetTacGia(int maTG);

        void ThemTacGia(TacGiaDTO tacGia);

        void SuaTacGia(TacGiaDTO tacGia);

        void XoaTacGia(int maTG);
    }
}