﻿using Application.DTOs;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IDoanDuLichService : IService<DoanDuLichDTO>
    {
        IEnumerable<KhachDTO> GetKhachsByDoan(int id);
        IEnumerable<NhanVienDTO> GetNVsByDoan(int id);
        IEnumerable<ChiPhiDTO> GetCPsByDoan(int id);
        void UpdateDoanhThu(int id);
    }
}
