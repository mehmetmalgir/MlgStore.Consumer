using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Models;
using MlgStore.WebUI.Models.Dtos;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;
using Newtonsoft.Json.Serialization;
using FluentValidation.Results;
using System.Text;
using MlgStore.WebUI.Models.Entities;

namespace MlgStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public IActionResult BuyProduct(int Id)
        {


            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri($"https://localhost:44365/api/Products/{Id}");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {              

                jsonContent = msg.Content.ReadAsStringAsync().Result;

                ApiProductDto pDto = new ApiProductDto();

                pDto = JsonConvert.DeserializeObject<ApiProductDto>(jsonContent);

                var jsonCustomer = HttpContext.Session.GetString("LoggedCustomerUser");
                var customer = JsonConvert.DeserializeObject<Customer>(jsonCustomer);
                Random r = new Random();

                client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44365/api/orders");


                var jsonStr = JsonConvert.SerializeObject(new
                {
                    CustomerID = customer.Id,
                    OrderNumber = r.Next(9999),
                    OrderDate = DateTime.Now,
                    ShipDate = DateTime.Now,
                    ShipperID = r.Next(7,10),
                    Freight = 1,
                    Paid = pDto.UnitPrice

                });



                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");

                msg = new HttpResponseMessage();

                msg = client.PostAsync(client.BaseAddress, content).Result;

                if (msg.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { IsSuccess = true });
                }

                return Json(new { IsSuccess = true });


            }
            else
            {

              
                return Json(new { isSuccess = false});


            }








        }
         

       
    }
}
