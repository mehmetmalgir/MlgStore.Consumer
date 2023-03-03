using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MlgStore.WebUI.Areas.Admin.Data;
using MlgStore.WebUI.Models;
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

    }
}
