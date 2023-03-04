using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Controllers
{
	public class ContactController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
