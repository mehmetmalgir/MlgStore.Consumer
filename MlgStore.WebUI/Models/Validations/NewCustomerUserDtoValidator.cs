using FluentValidation;
using MlgStore.WebUI.Models.Dtos;

namespace MlgStore.WebUI.Models.Validations
{
    public class NewCustomerUserDtoValidator : AbstractValidator<NewCustomerUserDto>
    {
        public NewCustomerUserDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Boş Bırakılamaz");

            RuleFor(x => x.Address1)
                .NotEmpty()
                .WithMessage("Adres Boş Bırakılamaz");            

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("İsim Boş Bırakılamaz");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Soyisim Boş Bırakılamaz");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre Boş Bırakılamaz");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage("Telefon Boş Bırakılamaz");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("İl Boş Bırakılamaz");

            RuleFor(x => x.District)
                .NotEmpty()
                .WithMessage("İlçe Boş Bırakılamaz");



        }


    }
}
