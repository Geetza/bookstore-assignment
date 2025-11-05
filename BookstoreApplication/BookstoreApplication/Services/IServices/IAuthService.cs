using System.Security.Claims;
using BookstoreApplication.DTOs.Request;
using BookstoreApplication.DTOs.Response;

namespace BookstoreApplication.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<ProfileDto> GetProfile(ClaimsPrincipal userPrincipal);
    }
}
