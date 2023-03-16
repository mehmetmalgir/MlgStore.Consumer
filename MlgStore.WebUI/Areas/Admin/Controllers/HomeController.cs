using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MlgStore.WebUI.Areas.Admin.Data;
using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using MlgStore.WebUI.Models.Dtos;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var jsonStr = HttpContext.Session.GetString("LoggedAdminUser");

            if (string.IsNullOrEmpty(jsonStr))
                return Redirect("Admin/Authentication/LogIn");


			HttpClient client = new HttpClient();
			HttpResponseMessage msg = null;
			string jsonContent = string.Empty;


			client.BaseAddress = new Uri("https://localhost:44365/api/orders");
			msg = client.GetAsync(client.BaseAddress).Result;

			if (msg.StatusCode == HttpStatusCode.OK)
			{

				ModelForHomePage viewModel = new ModelForHomePage();

				jsonContent = msg.Content.ReadAsStringAsync().Result;
				viewModel.Orders = JsonConvert.DeserializeObject<List<ApiOrderDto>>(jsonContent);

				client = new HttpClient();
				client.BaseAddress = new Uri("https://localhost:44365/api/complaints");
				msg = client.GetAsync(client.BaseAddress).Result;
				jsonContent = msg.Content.ReadAsStringAsync().Result;
				viewModel.Complaints = JsonConvert.DeserializeObject<List<ApiComplaintsDto>>(jsonContent);
								

				return View(viewModel);
			}


			return null;


        }
    }
}
