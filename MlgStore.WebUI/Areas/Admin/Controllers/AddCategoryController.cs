using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Data;
using MlgStore.WebUI.Areas.Admin.Models;
using MlgStore.WebUI.Areas.Admin.Validations;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Text;
using System;
using Microsoft.AspNetCore.Hosting;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class AddCategoryController : Controller
    {
        private IHostingEnvironment _hostingEnv;

        public AddCategoryController(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }

        [Area("Admin")]
        public IActionResult Index()
        {

            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(NewCategoryDto dto)
        {

            NewCategoryDtoValidator validator = new NewCategoryDtoValidator();
            var result = validator.Validate(dto);

            if (result.IsValid)
            {
                var file = dto.Picture;

                if (!file.ContentType.StartsWith("image/"))
                {
                    return Json(new { isSuccess = false, Message = "<div class = 'alert alert-warning'><div>Sadece Resim Dosyası Seçebilirsiniz</div></div>" });
                }

                if (file.Length > 2 * 1024 * 1024)
                {
                    return Json(new { isSuccess = false, Message = "<div class = 'alert alert-warning'><div>Dosya Boyutu 2mb'dan büyük olmamalıdır.</div></div>" });
                }


                string fileExtension = Path.GetExtension(file.FileName);

                string fileName = Guid.NewGuid().ToString() + fileExtension;

                string path = $"{_hostingEnv.WebRootPath}/CategoryPhotos/" + fileName;

                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                }

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44365/api/Categories");


                var jsonStr = JsonConvert.SerializeObject(new
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description,
                    Picture = fileName
                });



                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");


                HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

                if (msg.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { IsSuccess = true, Message = "Kategori Başarıyla Kaydedildi" });
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
