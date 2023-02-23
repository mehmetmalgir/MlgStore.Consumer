using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using MlgStore.WebUI.Areas.Admin.Validations;
using System.IO;
using System.Text;
using FluentValidation.Results;
using Microsoft.AspNetCore.Hosting;

namespace MlgStore.WebUI.Areas.Admin.Controllers
{
    public class AddProductController : Controller
    {
        private IHostingEnvironment _hostingEnv;

        public AddProductController(IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
        }



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

        [Area("Admin")]
        [HttpPost]
        public IActionResult Index(NewProductDto dto) 
        { 

            NewProductDtoValidator validator = new NewProductDtoValidator();
            var result = validator.Validate(dto);

            if(result.IsValid) 
            {
                var file = dto.ProductPhoto;

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

                string path = $"{_hostingEnv.WebRootPath}/ProductPhotos/" + fileName;

                using (FileStream fs = System.IO.File.Create(path))
                {
                    file.CopyTo(fs);
                }

                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("https://localhost:44365/api/products");


                var jsonStr = JsonConvert.SerializeObject(new
                {
                    ProductName = dto.ProductName,
                    CategoryID = dto.CategoryID,
                    QuantityPerUnit = dto.QuantityPerUnit,
                    UnitPrice = dto.UnitPrice,
                    SizeID = dto.SizeID,
                    ColorID = dto.ColorID,
                    DiscountAvailable = dto.DiscountAvailable,
                    CurrentOrder = dto.CurrentOrder,
                    GenderID = dto.GenderID,
                    ProductPhoto = fileName
                });



                StringContent content = new StringContent(jsonStr, Encoding.UTF8, "application/json");


                HttpResponseMessage msg = client.PostAsync(client.BaseAddress, content).Result;

                if (msg.StatusCode == HttpStatusCode.Created)
                {
                    return Json(new { IsSuccess = true, Message = "Ürün Başarıyla Kaydedildi" });
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
