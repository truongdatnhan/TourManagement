using Application.DTOs;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Mappings
{
    public static class NhanVienMapping
    {        
        public static NhanVienDTO MappingNhanVienDto(this AppUser nhanvien)
        {
            return new NhanVienDTO
            {
                Id = nhanvien.Id,
                HoNV = nhanvien.HoNV,
                TenNV = nhanvien.TenNV,
                DoBNV = nhanvien.DoBNV,
                PhoneNumber = nhanvien.PhoneNumber,
                Email = nhanvien.Email
            };
        }

        public static AppUser MappingNhanVien(this NhanVienDTO nhanvienDto)
        {
            return new AppUser
            {
                //Id = nhanvienDto.Id,
                HoNV = nhanvienDto.HoNV,
                TenNV = nhanvienDto.TenNV,               
                DoBNV = nhanvienDto.DoBNV,
                PhoneNumber = nhanvienDto.PhoneNumber,
                Email = nhanvienDto.Email,
                UserName = nhanvienDto.Email
            };
        }

        public static void MappingNhanVien(this NhanVienDTO nhanvienDto, AppUser nhanVien)
        {
            //nhanVien.Id = nhanvienDto.Id;
            nhanVien.HoNV = nhanvienDto.HoNV;
            nhanVien.TenNV = nhanvienDto.TenNV;           
            nhanVien.DoBNV = nhanvienDto.DoBNV;
            nhanVien.PhoneNumber = nhanvienDto.PhoneNumber;
            nhanVien.Email = nhanvienDto.Email;
            nhanVien.UserName = nhanvienDto.Email;
        }

        public static IEnumerable<NhanVienDTO> MappingNhanVienDtos(this IEnumerable<AppUser> nhanviens)
        {
            foreach (var nhanVien in nhanviens)
            {
                yield return nhanVien.MappingNhanVienDto();
            }
        }
    }
}
