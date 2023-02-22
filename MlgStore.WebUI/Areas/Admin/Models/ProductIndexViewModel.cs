using System.Collections.Generic;

namespace MlgStore.WebUI.Areas.Admin.Models
{
    public class ProductIndexViewModel
    {
        public List<ApiProductDto> Products { get; set; }
        public List<ApiCategoriesDto> Categories { get; set; }
        public List<ApiColorDto> Colors { get; set; }
        public List<ApiGenderDto> Genders { get; set; }
        public List<ApiShipperDto> Shippers { get; set; }
        public List<ApiSizeDto> Sizes { get; set; }
       

    }
}
