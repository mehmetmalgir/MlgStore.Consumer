using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
