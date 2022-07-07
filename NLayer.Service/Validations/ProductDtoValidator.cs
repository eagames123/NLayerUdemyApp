using FluentValidation;
using NLayer.Core.DTOs;

namespace NLayer.Service.Validations
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            //Not:String bir referans tiptir.
            RuleFor(x => x.Name).NotNull().WithMessage("{PropertyName} is Required").NotEmpty().WithMessage("{PropertyName} is Required");

            //Value tiplerin default değerleri vardır. Decimal bir değer tipi olduğundan not null ve not empty kontolleri işe yaramaz.
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");

            RuleFor(x => x.Stock).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be gerater 0");

            //RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("{PropertyName} must be greater 0");
        }
    }
}
