using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Models.Contexts;
using MlgStore.WebUI.Models.Dtos;
using MlgStore.WebUI.Models.Validations;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using MlgStore.WebUI.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
                
                Response.Cookies.Append("LoggedCustomerUser", jsonStr);

                string addedCustomer = Request.Cookies["LoggedCustomerUser"];



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

        [HttpPost]
        public IActionResult Register(NewCustomerUserDto dto)
        {
            NewCustomerUserDtoValidator validator = new NewCustomerUserDtoValidator();
            var result = validator.Validate(dto);

            if(result.IsValid)
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44365/api/Customers");


                var jsonStr = JsonConvert.SerializeObject(new
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Address1 = dto.Address1,
                    Address2 = dto.Address2,
                    City = dto.City,
                    District = dto.District,
                    Phone = dto.Phone,
                    Email = dto.Email,
                    Password = dto.Password,
                    RegistirationDate = DateTime.Now
                });



                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");


                HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

                if (msg.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { IsSuccess = true, Message = "Yeni Üye Oluşturuldu" });
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
