using Application.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateUserAsync(SignUpDTO signUpDTO);
        Task<IdentityResult> CreateUserAsync(NhanVienDTO nhanvienDto);
        Task<SignInResult> PasswordSignInAsync(LogInDTO logInDTO);
        Task<IdentityResult> UpdateUserAsync(NhanVienDTO nhanvienDto);
        Task SignOutAsync();
    }
}