using FluentValidation;

namespace ShopDBProduct.Validators.Reusable
{
    public static class NumberRules
    {
        public static IRuleBuilderOptions<T, decimal> ValidPrice<T>(this IRuleBuilder<T, decimal> rule)
        {
            return rule.GreaterThan(0).WithMessage("Price must be greater than 0!").LessThanOrEqualTo(10_000_000).WithMessage("Price must be less than or equal 10 million!");
        }
        public static IRuleBuilderOptions<T, int> ValidPositiveNumber<T>(this IRuleBuilder<T, int> rule)
        {
            return rule.GreaterThan(0).WithMessage("Must be greater than 0!");
        }
    }
}
