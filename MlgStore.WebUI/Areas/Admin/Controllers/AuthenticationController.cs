using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using MlgStore.WebUI.Areas.Admin.Models;
using MlgStore.WebUI.Areas.Admin.Validations;
using MlgStore.WebUI.Models.Contexts;
using Newtonsoft.Json;
using System.Linq;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthenticationController : Controller
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }



        [HttpPost]
        public IActionResult LogIn(LogInDto dto)
        {
            LogInDtoValidator validator = new LogInDtoValidator();
            ValidationResult result = validator.Validate(dto);

            if (result.IsValid)
            {
                MlgStoreDbContext ctx = new MlgStoreDbContext();
                var user = ctx.UsersAdmin.SingleOrDefault(x => x.UserName == dto.UserName && x.Password == dto.Password);
                
                if (user == null)
                {
                    return Json(new { isSuccess = false, Message = "Kullanıcı Bulunamadı!" });
                }

                var jsonStr = JsonConvert.SerializeObject(user);

                HttpContext.Session.SetString("LoggedAdminUser", jsonStr);

                return Json(new { isSuccess = true });
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
