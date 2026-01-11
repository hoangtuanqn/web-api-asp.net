using FluentValidation;

namespace ShopDBProduct.Validators.Reusable
{
    public static class NameRules
    {
        public static IRuleBuilderOptions<T, string> ValidName<T>(this IRuleBuilder<T, string> rule) 
        {
            return rule
                .NotEmpty().WithMessage("Name is required!")
                .MaximumLength(255).WithMessage("Name must be less 255 characters long!");
        }
    }
}
