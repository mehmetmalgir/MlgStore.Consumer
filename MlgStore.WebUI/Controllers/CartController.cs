using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Models;
using MlgStore.WebUI.Models.Dtos;
using Newtonsoft.Json;

namespace MlgStore.WebUI.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}


		[HttpPost]
		public IActionResult ShowCartProducts(ProductIndexViewModel dto)
		{
			
			

			return View();
		}






	}
}
