using FluentValidation;

namespace ShopDBProduct.Validators.Reusable
{
    public static class PriceRules
    {
        public static IRuleBuilderOptions<T, decimal> ValidPrice<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule.GreaterThan(0).WithMessage("Price must be greater than 0!").LessThanOrEqualTo(10_000_000).WithMessage("Price must be less than or equal 10 million!");
        }
    }
}
