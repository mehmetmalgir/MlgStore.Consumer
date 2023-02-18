using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
