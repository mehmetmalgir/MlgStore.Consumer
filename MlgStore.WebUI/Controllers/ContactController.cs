using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Models.Dtos;
using MlgStore.WebUI.Models.Validations;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System;

namespace MlgStore.WebUI.Controllers
{
	public class ContactController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Index(SendComplaintsDto dto)
		{

			SendComplaintDtoValidator validator = new SendComplaintDtoValidator();
			var result = validator.Validate(dto);

			if(result.IsValid) 
			{
				HttpClient client = new HttpClient();

				client.BaseAddress = new Uri("https://localhost:44365/api/Complaints");


				var jsonStr = JsonConvert.SerializeObject(new
				{
					Email = dto.Email,
					Description = dto.Description					
				});



				StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");


				HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

				if (msg.StatusCode == HttpStatusCode.Created)
				{
					return Json(new { IsSuccess = true, Message = "Görüş ve Şikayetiniz Alındı" });
				}

				return Json(new { IsSuccess = false });
			}
			else
			{
				string errorMessages = "<div class = 'alert alert-warning'>";
				foreach (ValidationFailure item in result.Errors)
				{
					errorMessages += $"<div>{item.ErrorMessage}</div>";
				}

				errorMessages += "</div>";

				return Json(new { isSuccess = false, Message = errorMessages });
			}
			

		}

	}
}
