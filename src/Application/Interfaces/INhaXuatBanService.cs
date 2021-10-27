using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces
{
    public interface INhaXuatBanService
    {
        IEnumerable<NhaXuatBanDTO> GetNhaXuatBans(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);

        NhaXuatBanDTO GetNhaXuatBan(int maNXB);

        void ThemNhaXuatBan(NhaXuatBanDTO nhaXuatBan);

        void SuaNhaXuatBan(NhaXuatBanDTO nhaXuatBan);

        void XoaNhaXuatBan(int maNXB);
    }
}