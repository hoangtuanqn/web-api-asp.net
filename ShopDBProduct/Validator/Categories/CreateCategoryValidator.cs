
using FluentValidation;
using ShopDBProduct.DTOs.Categories;

namespace ShopDBProduct.Validator.Categories
{
    public class CreateCategoryValidator: AbstractValidator<CreateCategoryDto>
    {
        // constructor
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().Length(1, 255).WithName("Tên danh mục phải từ 1 đến 255 ký tự!");
            RuleFor(x => x.Description).NotEmpty().Length(1, 500).WithName("Mô tả danh mục phải dưới 500 ký tự!");
            RuleFor(x => x.Status).NotNull().WithMessage("Status không hợp lệ!");
        }
    }
}
