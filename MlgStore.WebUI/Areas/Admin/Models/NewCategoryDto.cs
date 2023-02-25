using Microsoft.AspNetCore.Http;

namespace MlgStore.WebUI.Areas.Admin.Models
{
    public class NewCategoryDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }

    }
}
