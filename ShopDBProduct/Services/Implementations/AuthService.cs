using ShopDBProduct.DTOs.Users;
using ShopDBProduct.Entities;
using ShopDBProduct.Services.Interfaces;
using ShopDBProduct.Utils;

namespace ShopDBProduct.Services.Implementations
{
    public class AuthService : IAuthService
    {  
        private readonly JwtTokenGenerator _jwt;
        public AuthService(JwtTokenGenerator jwt)
        {
            _jwt = jwt;
        }
        public AuthResponseDto Login(User user, string password)
        {
            if (!BCrypt.Net.BCrypt.Verify(password, user.Password))
                throw new UnauthorizedAccessException("Sai thông tin đăng nhập");

            return _jwt.GenerateAccessToken(user);
        }
    }
}
