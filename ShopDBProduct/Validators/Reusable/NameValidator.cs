using FluentValidation;

namespace ShopDBProduct.Validators.Reusable
{
    public class NameValidator: AbstractValidator<string>
    {
        public NameValidator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("Name is required!")
                .MaximumLength(255).WithMessage("Name must be less 255 characters long!");
        }
    }
}
