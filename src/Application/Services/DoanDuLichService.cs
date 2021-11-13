using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DoanDuLichService : IDoanDuLichService
    {
        private readonly IDoanDuLichRepository doanDuLichRepository;
        private readonly INoiDungTourRepository noiDungTourRepository;
        private readonly IKhachRepository khachRepository;
        private readonly IChiTietDoanRepository chiTietDoanRepository;
        private readonly INhanVienRepository nhanVienRepository;
        private readonly ILoaiChiPhiRepository loaiChiPhiRepository;
        private readonly IMapper mapper;

        public DoanDuLichService(IDoanDuLichRepository doanDuLichRepository,INoiDungTourRepository noiDungTourRepository,
            IKhachRepository khachRepository,IChiTietDoanRepository chiTietDoanRepository, 
            INhanVienRepository nhanVienRepository, ILoaiChiPhiRepository loaiChiPhiRepository ,IMapper mapper)
        {
            this.doanDuLichRepository = doanDuLichRepository;
            this.noiDungTourRepository = noiDungTourRepository;
            this.khachRepository = khachRepository;
            this.chiTietDoanRepository = chiTietDoanRepository;
            this.nhanVienRepository = nhanVienRepository;
            this.loaiChiPhiRepository = loaiChiPhiRepository;
            this.mapper = mapper;
        }

        #region Đoàn Du Lịch

        public bool Create(DoanDuLichDTO dto)
        {
            var doan = mapper.Map<DoanDuLich>(dto);
            doanDuLichRepository.Add(doan);
            return true;
        }

        public DoanDuLichDTO Get(int maDoan)
        {
            var doan = doanDuLichRepository.GetBy(maDoan);
            return mapper.Map<DoanDuLichDTO>(doan);
        }

        public bool Update(DoanDuLichDTO dto)
        {
            var doan = doanDuLichRepository.GetBy(dto.MaDoan);
            mapper.Map<DoanDuLichDTO, DoanDuLich>(dto, doan);
            doanDuLichRepository.Update(doan);
            return true;
        }

        public bool Delete(int maDoan)
        {
            var doan = doanDuLichRepository.GetBy(maDoan);
            doanDuLichRepository.Delete(doan);
            return true;
        }

        public IEnumerable<DoanDuLichDTO> GetDTOs(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var doans = doanDuLichRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return mapper.Map<IEnumerable<DoanDuLichDTO>>(doans);
        }

        #endregion

        /*
        #region Khách

        public IEnumerable<KhachDTO> GetKhach_DTOs(int id)
        {
            var ctds = doanDuLichRepository.GetDoans_Eager(id).ChiTietDoans;
            var khachs = khachRepository.GetAll().Where(x => ctds.Any(c => c.MaKhachHang == x.MaKhachHang));
            var khachDTOs = mapper.Map<IEnumerable<KhachDTO>>(khachs).ToList();
            var dtos = khachDTOs.Select(x => 
            { 
                x.VaiTro = ctds.Where(c => c.MaKhachHang == x.MaKhachHang).FirstOrDefault().VaiTro;
                return x;
            });
        }

        #endregion

        #region Nhân Viên
        public IEnumerable<NhanVienDTO> GetNV_DTOs(int id)
        {
            var pbs = doanDuLichRepository.GetDoans_Eager(id).PhanBoNhanVienDoans;
            var nvs = nhanVienRepository.GetAll().Where(x => pbs.Any(c => c.MaNhanVien == x.MaNhanVien));
            var nvDTOs = mapper.Map<IEnumerable<NhanVienDTO>>(nvs);
            var dtos = nvDTOs.Select(x =>
            {
                x.NhiemVu = pbs.Where(nv => nv.MaNhanVien == x.MaNhanVien).FirstOrDefault().NhiemVu;
                return x;
            });

            return dtos;
        }
        #endregion

        #region Chi Phí
        public IEnumerable<ChiPhiDTO> GetCP_DTOs(int id)
        {
            var cps = doanDuLichRepository.GetDoan_Eager(id).ChiPhis;
            var lcp = loaiChiPhiRepository.GetAll();
            var cpDTOs = mapper.Map<IEnumerable<ChiPhiDTO>>(cps);
            var dtos = cpDTOs.Select(x =>
            {
                x.TenLoaiChiPhi = lcp.Where(l => l.MaLoaiChiPhi == x.MaLoaiChiPhi).FirstOrDefault().TenLoaiChiPhi;
                return x;
            });
            return dtos;
        }
        #endregion
        */
    }
}
