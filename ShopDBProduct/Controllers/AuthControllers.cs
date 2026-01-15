using BCrypt.Net;
using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Users;
using ShopDBProduct.Entities;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Controllers
{
    public class AuthControllers : BaseApiController
    {

        private readonly IAuthService _authService;

        public AuthControllers(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            // Giả sử đã lấy user từ DB
            var user = new User
            {
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword("123456"),
            };

            var result = _authService.Login(user, dto.Password);
            return Ok(result);
        }
    }
}
