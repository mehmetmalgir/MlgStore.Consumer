﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net;
using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection.Metadata;
using MlgStore.WebUI.Areas.Admin.Data;

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

            GetDtosForViewModel gDto = new GetDtosForViewModel();
            var viewModel = gDto.GetProductsForViewModel();


            return View(viewModel);
        }
    }
}
