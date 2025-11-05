using BookstoreApplication.DTOs.Request;

namespace BookstoreApplication.Services.IServices
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDto dto);
        Task LoginAsync(LoginDto dto);
    }
}
