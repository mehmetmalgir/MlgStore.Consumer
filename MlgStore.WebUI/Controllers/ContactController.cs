using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Models.Dtos;
using MlgStore.WebUI.Models.Validations;

namespace MlgStore.WebUI.Controllers
{
	public class ContactController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult SendComplaints(SendComplaintsDto dto)
		{
			SendComplaintDtoValidator validator = new SendComplaintDtoValidator();
			var result = validator.Validate(dto);

			if(result.IsValid) 
			{
				
			}
			else
			{

			}




			return View();
		}



	}
}
