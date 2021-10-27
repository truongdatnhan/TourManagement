using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NhanVienService : INhanVienService
    {
        private readonly INhanVienRepository _nhanVienRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountService _accountService;

        public NhanVienService(INhanVienRepository nhanVienRepository, UserManager<AppUser> userManager, IAccountService accountService)
        {
            _nhanVienRepository = nhanVienRepository;
            _userManager = userManager;
            _accountService = accountService;
        }

        public IEnumerable<NhanVienDTO> GetNhanViens(string sortOrder, string searchString, int pageIndex, int pageSize, out int count)
        {
            var nhanViens = _nhanVienRepository.Filter(sortOrder, searchString, pageIndex, pageSize, out count);
            return nhanViens.MappingNhanVienDtos();
        }

        public NhanVienDTO GetNhanVien(int Id)
        {
            var nhanvien = _nhanVienRepository.GetBy(Id);

            return nhanvien.MappingNhanVienDto();
        }

        public async Task<IdentityResult> SuaNhanVien(NhanVienDTO nhanVienDto)
        {
            var nhanVien = nhanVienDto.MappingNhanVien();
            return await _accountService.UpdateUserAsync(nhanVienDto); 
        }

        public async Task<IdentityResult> ThemNhanVien(NhanVienDTO nhanVienDto)
        {
            var nhanVien = nhanVienDto.MappingNhanVien();
            return await _accountService.CreateUserAsync(nhanVienDto);
        }

    }
}
