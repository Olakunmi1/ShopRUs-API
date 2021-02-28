using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.ReadDTO
{
    public class InvoiceDTO
    {  
        public string ClientAddress { get; set; }
        public string InvoiceNumber { get; set; }

        public decimal TotalBill { get; set; }
        public decimal Discount { get; set; }
        public decimal DiscountedPrice { get; set; } //price after discount has been applied, also TotalPrice
        public DateTime Created_at { get; set; }
    }
}
