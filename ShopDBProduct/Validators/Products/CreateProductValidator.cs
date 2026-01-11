using FluentValidation;
using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Validators.Reusable;

namespace ShopDBProduct.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).ValidName();
            RuleFor(x => x.Price).ValidPrice();
            RuleFor(x => x.Quantity).ValidPositiveNumber();
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image must be required!");
            RuleFor(x => x.CategoryId).NotEmpty();
        }
    }
}
