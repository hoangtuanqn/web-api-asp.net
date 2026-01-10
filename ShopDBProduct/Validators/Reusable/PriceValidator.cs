using FluentValidation;

namespace ShopDBProduct.Validators.Reusable
{
    public class PriceValidator: AbstractValidator<decimal>
    {
        public PriceValidator()
        {
            RuleFor(x => x).GreaterThan(0).WithMessage("Price must be greater than 0!").LessThanOrEqualTo(10_000_000).WithMessage("Price must be less than or equal ten million!");
        }
    }
}
