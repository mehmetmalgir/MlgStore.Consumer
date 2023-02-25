using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Data;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class ShippersController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            var jsonStr = HttpContext.Session.GetString("LoggedAdminUser");

            if (string.IsNullOrEmpty(jsonStr))
                return Redirect("Admin/Authentication/LogIn");

            GetDtosForViewModel gDto = new GetDtosForViewModel();
            var viewModel = gDto.GetProductsForViewModel();


            return View(viewModel);
        }
    }
}
