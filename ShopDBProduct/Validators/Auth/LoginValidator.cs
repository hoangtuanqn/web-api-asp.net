using FluentValidation;
using ShopDBProduct.DTOs.Users;

namespace ShopDBProduct.Validators.Auth
{
    public class LoginValidator: AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email của bạn không hợp lệ!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Mật khẩu phải có tối thiểu 6 kí tự");
        }
    }
}
