using System;

namespace MlgStore.WebUI.Models.Dtos
{
    public class NewOrder
    {
        public int? CustomerID { get; set; }
        public long OrderNumber { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? ShipperID { get; set; }
        public decimal? Freight { get; set; }
        public decimal? Paid { get; set; }

    }
}
