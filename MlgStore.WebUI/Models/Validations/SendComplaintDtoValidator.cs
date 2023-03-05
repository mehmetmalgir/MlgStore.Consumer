using FluentValidation;
using MlgStore.WebUI.Models.Dtos;

namespace MlgStore.WebUI.Models.Validations
{
	public class SendComplaintDtoValidator : AbstractValidator<SendComplaintsDto>
	{
		public SendComplaintDtoValidator()
		{

			RuleFor(x => x.Email)
				.NotEmpty()
				.WithMessage("Email Boş Bırakılamaz");

			RuleFor(x => x.Description)
				.NotEmpty()
				.WithMessage("Açıklama Kısmı Boş Bırakılamaz");




		}

	}
}
