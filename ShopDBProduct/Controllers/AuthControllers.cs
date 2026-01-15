using BCrypt.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Products;
using ShopDBProduct.DTOs.Users;
using ShopDBProduct.Entities;
using ShopDBProduct.Services.Interfaces;
using System.Threading.Tasks;

namespace ShopDBProduct.Controllers
{
    public class AuthControllers : BaseApiController
    {

        private readonly IAuthService _authService;
        private readonly IValidator<LoginDto> _loginValidator;

        public AuthControllers(IAuthService authService, IValidator<LoginDto> loginValidator)
        {
            _authService = authService;
            _loginValidator = loginValidator;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var valid = await _loginValidator.ValidateAsync(dto);
            if (!valid.IsValid)
            {
                return BadRequest(valid.Errors);
            }
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
