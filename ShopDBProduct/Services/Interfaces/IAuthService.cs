using ShopDBProduct.DTOs.Users;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Services.Interfaces
{
    public interface IAuthService
    {
        public AuthResponseDto Login(User user, string password);

    }
}
