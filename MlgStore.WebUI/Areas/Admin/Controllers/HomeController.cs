using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string jsonStr = HttpContext.Session.GetString("LoggedAdminUser");


            if(string.IsNullOrEmpty(jsonStr))            
                return Redirect("/Admin/Authentication/LogIn");
           


            return View();
        }
    }
}
