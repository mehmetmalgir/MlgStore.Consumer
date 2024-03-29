﻿using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using System.Linq;
using MlgStore.WebUI.Methods;

namespace MlgStore.WebUI.Controllers
{
	public class WomanJewelryController : Controller
	{
		public IActionResult Index()
		{
            GetProducts gp = new GetProducts();
            var viewModel = gp.GetWomanProductsByCategory(12);
            return View(viewModel);


            #region Without Method
            //HttpClient client = new HttpClient();
            //HttpResponseMessage msg = null;
            //string jsonContent = string.Empty;


            //client.BaseAddress = new Uri("https://localhost:44365/api/Products/getbygender?genderId=2");
            //msg = client.GetAsync(client.BaseAddress).Result;

            //if (msg.StatusCode == HttpStatusCode.OK)
            //{

            //	ProductIndexViewModel viewModel = new ProductIndexViewModel();

            //	jsonContent = msg.Content.ReadAsStringAsync().Result;

            //	viewModel.Products = JsonConvert.DeserializeObject<List<ApiProductDto>>(jsonContent).Where(x => x.CategoryID == 12).ToList();


            //	client = new HttpClient();
            //	client.BaseAddress = new Uri("https://localhost:44365/api/Categories");
            //	msg = client.GetAsync(client.BaseAddress).Result;
            //	jsonContent = msg.Content.ReadAsStringAsync().Result;
            //	viewModel.Categories = JsonConvert.DeserializeObject<List<ApiCategoriesDto>>(jsonContent);

            //	client = new HttpClient();
            //	client.BaseAddress = new Uri("https://localhost:44365/api/Colors");
            //	msg = client.GetAsync(client.BaseAddress).Result;
            //	jsonContent = msg.Content.ReadAsStringAsync().Result;
            //	viewModel.Colors = JsonConvert.DeserializeObject<List<ApiColorDto>>(jsonContent);

            //	client = new HttpClient();
            //	client.BaseAddress = new Uri("https://localhost:44365/api/Genders");
            //	msg = client.GetAsync(client.BaseAddress).Result;
            //	jsonContent = msg.Content.ReadAsStringAsync().Result;
            //	viewModel.Genders = JsonConvert.DeserializeObject<List<ApiGenderDto>>(jsonContent);

            //	client = new HttpClient();
            //	client.BaseAddress = new Uri("https://localhost:44365/api/Sizes");
            //	msg = client.GetAsync(client.BaseAddress).Result;
            //	jsonContent = msg.Content.ReadAsStringAsync().Result;
            //	viewModel.Sizes = JsonConvert.DeserializeObject<List<ApiSizeDto>>(jsonContent);

            //	client = new HttpClient();
            //	client.BaseAddress = new Uri("https://localhost:44365/api/Shippers");
            //	msg = client.GetAsync(client.BaseAddress).Result;
            //	jsonContent = msg.Content.ReadAsStringAsync().Result;
            //	viewModel.Shippers = JsonConvert.DeserializeObject<List<ApiShipperDto>>(jsonContent);

            //	return View(viewModel);
            //}

            //return null; 
            #endregion
        }
	}
}
