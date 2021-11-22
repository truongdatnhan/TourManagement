using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IDoanDuLichRepository : IEFRepository<DoanDuLich>
    {
        int CountDoanDuLich();

        IEnumerable<DoanDuLich> GetDoans();
        void UpdateDoanhThu(int id);
        DoanDuLich GetDoan_Eager(int id);
        IEnumerable<DoanDuLich> Filter(string sortOrder, string searchString, int pageIndex, int pageSize, out int count);
        IEnumerable<Khach> GetKhachsByDoan(int id);
        IEnumerable<NhanVien> GetNVsByDoan(int id);
        IEnumerable<ChiPhi> GetCPsByDoan(int id);
    }
}