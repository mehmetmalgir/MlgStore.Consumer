using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net;
using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            string jsonStr = HttpContext.Session.GetString("LoggedAdminUser");

            if (string.IsNullOrEmpty(jsonStr))
                return Redirect("Admin/Authentication/LogIn");


            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri("https://localhost:44365/api/Products");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {

                ProductIndexViewModel viewModel = new ProductIndexViewModel();

                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Products = JsonConvert.DeserializeObject<List<ApiProductDto>>(jsonContent);

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Categories");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Categories = JsonConvert.DeserializeObject<List<ApiCategoriesDto>>(jsonContent);

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Colors");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Colors = JsonConvert.DeserializeObject<List<ApiColorDto>>(jsonContent);

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Genders");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Genders = JsonConvert.DeserializeObject<List<ApiGenderDto>>(jsonContent);

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Sizes");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Sizes = JsonConvert.DeserializeObject<List<ApiSizeDto>>(jsonContent);




                return View(viewModel);

            }
            else
                return null;


            
        }
    }
}
