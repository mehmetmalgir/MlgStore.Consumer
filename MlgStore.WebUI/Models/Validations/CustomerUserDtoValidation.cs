using FluentValidation;
using MlgStore.WebUI.Models.Dtos;

namespace MlgStore.WebUI.Models.Validations
{
    public class CustomerUserDtoValidation : AbstractValidator<CustomerUserDto>
    {
        public CustomerUserDtoValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Boş Bırakılamaz!");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Şifre Boş Bırakılamaz!");
        }



    }
}
