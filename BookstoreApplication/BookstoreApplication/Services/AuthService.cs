using AutoMapper;
using BookstoreApplication.Domain;
using BookstoreApplication.DTOs.Request;
using BookstoreApplication.Exceptions;
using BookstoreApplication.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace BookstoreApplication.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task RegisterAsync(RegistrationDto dto)
        {
            var user = _mapper.Map<ApplicationUser>(dto);
            
            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
            {
                string errorMessage = string.Join("; ", result.Errors.Select(e => e.Description));
                throw new BadRequestException(errorMessage);
            }
        }

        public async Task LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
                throw new BadRequestException("Invalid credentials");

            var passwordMatch = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!passwordMatch)
                throw new BadRequestException($"{dto.Username} password mismatch");
        }
    }
}
