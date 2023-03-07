using MlgStore.WebUI.Areas.Admin.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System;
using System.Security.Policy;
using System.Linq;

namespace MlgStore.WebUI.Methods
{
    public class GetProducts
    {
        public ProductIndexViewModel GetProductsByCategory(Uri uri)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;

            string stringUri = Convert.ToString(uri);

            client.BaseAddress = new Uri(stringUri);

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

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Shippers");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Shippers = JsonConvert.DeserializeObject<List<ApiShipperDto>>(jsonContent);

                return viewModel;
            }

            return null;
        }

        public ProductIndexViewModel GetProductsByGender(Uri uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;

            string stringUri = Convert.ToString(uri);

            client.BaseAddress = new Uri(stringUri);

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

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Shippers");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Shippers = JsonConvert.DeserializeObject<List<ApiShipperDto>>(jsonContent);

                return viewModel;
            }

            return null;
        }

        public ProductIndexViewModel GetManProductsByCategory(int categoryId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri("https://localhost:44365/api/Products/getbygender?genderId=1");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {

                ProductIndexViewModel viewModel = new ProductIndexViewModel();

                jsonContent = msg.Content.ReadAsStringAsync().Result;

                viewModel.Products = JsonConvert.DeserializeObject<List<ApiProductDto>>(jsonContent).Where(x => x.CategoryID == categoryId).ToList();


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

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Shippers");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Shippers = JsonConvert.DeserializeObject<List<ApiShipperDto>>(jsonContent);

                return viewModel;
            }

            return null;
        }

        public ProductIndexViewModel GetWomanProductsByCategory(int categoryId)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage msg = null;
            string jsonContent = string.Empty;


            client.BaseAddress = new Uri("https://localhost:44365/api/Products/getbygender?genderId=2");
            msg = client.GetAsync(client.BaseAddress).Result;

            if (msg.StatusCode == HttpStatusCode.OK)
            {

                ProductIndexViewModel viewModel = new ProductIndexViewModel();

                jsonContent = msg.Content.ReadAsStringAsync().Result;

                viewModel.Products = JsonConvert.DeserializeObject<List<ApiProductDto>>(jsonContent).Where(x => x.CategoryID == categoryId).ToList();


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

                client = new HttpClient();
                client.BaseAddress = new Uri("https://localhost:44365/api/Shippers");
                msg = client.GetAsync(client.BaseAddress).Result;
                jsonContent = msg.Content.ReadAsStringAsync().Result;
                viewModel.Shippers = JsonConvert.DeserializeObject<List<ApiShipperDto>>(jsonContent);

                return viewModel;
            }

            return null;

        }




    }
  
}
