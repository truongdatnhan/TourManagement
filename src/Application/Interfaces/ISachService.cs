using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface ISachService
    {
        IEnumerable<SachDTO> GetSachs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);

        SachDTO GetSach(int maS);

        bool ThemSach(SachDTO sach);

        bool SuaSach(SachDTO sach);

        void XoaSach(int maS);
    }
}