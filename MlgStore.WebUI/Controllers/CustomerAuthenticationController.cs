using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Models.Contexts;
using MlgStore.WebUI.Models.Dtos;
using MlgStore.WebUI.Models.Validations;
using Newtonsoft.Json;
using System.Linq;

namespace MlgStore.WebUI.Controllers
{
    public class CustomerAuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(CustomerUserDto dto)
        {
            CustomerUserDtoValidation validation = new CustomerUserDtoValidation();
            var result = validation.Validate(dto);

            if (result.IsValid)
            {
                MlgStoreDbContext ctx = new MlgStoreDbContext();
                var customer = ctx.Customers.SingleOrDefault(x => x.Email == dto.Email && x.Password == dto.Password);

                if(customer == null)
                {
                    return Json(new { isSuccess = false, Message = "Kullanıcı Bulunamadı!" });
                }

                var jsonStr = JsonConvert.SerializeObject(customer);

                HttpContext.Session.SetString("LoggedCustomerUser", jsonStr);

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
