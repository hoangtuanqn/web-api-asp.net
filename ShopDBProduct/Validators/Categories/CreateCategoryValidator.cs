
using FluentValidation;
using ShopDBProduct.DTOs.Categories;
using ShopDBProduct.Validators.Reusable;

namespace ShopDBProduct.Validator.Categories
{
    public class CreateCategoryValidator: AbstractValidator<CreateCategoryDto>
    {
        // constructor
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).ValidName();
            RuleFor(x => x.Description).Length(1, 500).WithMessage("Mô tả danh mục phải dưới 500 ký tự!");
            RuleFor(x => x.Status).NotNull().WithMessage("Status không hợp lệ!");
        }
    }
}
