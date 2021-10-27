using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDTO signUpDTO)
        {
            var user = new AppUser()
            {
                //mapping trực tiếp
                HoNV = signUpDTO.HoNV,
                TenNV = signUpDTO.TenNV,
                DoBNV = signUpDTO.DoBNV,
                PhoneNumber = signUpDTO.PhoneNumber,
                Email = signUpDTO.Email,
                UserName = signUpDTO.Email
            };

            var result = await _userManager.CreateAsync(user, signUpDTO.Password);
            return result;
        }
        public async Task<IdentityResult> CreateUserAsync(NhanVienDTO nhanvienDto)
        {
            var user = new AppUser()
            {
                //mapping trực tiếp
                HoNV = nhanvienDto.HoNV,
                TenNV = nhanvienDto.TenNV,
                DoBNV = nhanvienDto.DoBNV,
                PhoneNumber = nhanvienDto.PhoneNumber,
                Email = nhanvienDto.Email,
                UserName = nhanvienDto.Email
            };

            var result = await _userManager.CreateAsync(user, nhanvienDto.PasswordNV);
            return result;
        }

        public async Task<IdentityResult> UpdateUserAsync(NhanVienDTO nhanvienDto)
        {
            var user = await _userManager.FindByEmailAsync(nhanvienDto.Email);
            user.HoNV = nhanvienDto.HoNV;
            user.TenNV = nhanvienDto.TenNV;
            user.DoBNV = nhanvienDto.DoBNV;
            user.PhoneNumber = nhanvienDto.PhoneNumber;
            user.Email = nhanvienDto.Email;
            user.UserName = nhanvienDto.Email;

            var result = await _userManager.UpdateAsync(user);
            return result;
        }
        
        /*
        public async Task<IdentityResult> DeleteUserAsync(NhanVienDTO nhanvienDto)
        {
            var user = await _userManager.FindByEmailAsync(nhanvienDto.Email);

            var result = await _userManager.DeleteAsync(user);
            return result;
        }
        */

        public async Task<SignInResult> PasswordSignInAsync(LogInDTO logInDTO)
        {
            return await _signInManager.PasswordSignInAsync(logInDTO.Email, logInDTO.Password, logInDTO.RememberMe, true);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        /*public async Task GetClaimsAsync(LogInDTO logInDTO)
        {
            var user = await _userManager.FindByEmailAsync(logInDTO.Email);
            var result = await _userManager.GetClaimsAsync(user);
            return result;
        }*/

    }
}