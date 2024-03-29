﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MlgStore.WebUI.Areas.Admin.Data;
using MlgStore.WebUI.Models;
using MlgStore.WebUI.Models.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MlgStore.WebUI.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
			
            return View();
            			
        }

        public IActionResult HideAndShowWithLogIn()
        {

			var jsonContent = HttpContext.Session.GetString("LoggedCustomerUser");
			if (jsonContent != null)
			{
				var customerModel = JsonConvert.DeserializeObject<Customer>(jsonContent);
				return Json(new { isSuccess = true });
                
			}

			return Json(new { isSuccess = false });
		}




    }
}
