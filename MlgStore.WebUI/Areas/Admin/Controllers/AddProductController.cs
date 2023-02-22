using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class AddProductController : Controller
    {
        [Area("Admin")]
        [HttpPost]
        public IActionResult Index()
        {
            return View();
        }
    }
}
