using FluentValidation;
using MlgStore.WebUI.Areas.Admin.Models;

namespace MlgStore.WebUI.Areas.Admin.Validations
{
    public class NewCategoryDtoValidator : AbstractValidator<NewCategoryDto>
    {
        public NewCategoryDtoValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty()
                .WithMessage("Kategori İsmi Boş Bırakılamaz");

            
        }
    }
}
