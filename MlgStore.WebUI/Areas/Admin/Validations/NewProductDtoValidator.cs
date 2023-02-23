using FluentValidation;
using MlgStore.WebUI.Areas.Admin.Models;

namespace MlgStore.WebUI.Areas.Admin.Validations
{
    public class NewProductDtoValidator : AbstractValidator<NewProductDto>
    {
        public NewProductDtoValidator()
        {

            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Ürün Adı Boş Bırakılamaz");

            RuleFor(x => x.UnitPrice)
                .NotEmpty()
                .WithMessage("Ürün Fiyatı Boş Bırakılamaz");

            RuleFor(x => x.QuantityPerUnit)
                .NotEmpty()
                .WithMessage("Ürün Fiyatı Boş Bırakılamaz");

            


        }


    }
}
