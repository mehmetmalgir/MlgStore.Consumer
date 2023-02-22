namespace MlgStore.WebUI.Areas.Admin.Models
{
    public class ApiProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int QuantityPerUnit { get; set; }
        public int UnitPrice { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string GenderType { get; set; }
        public int Discount { get; set; }
        public string Picture { get; set; }



    }
}
