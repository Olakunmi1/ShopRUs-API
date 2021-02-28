using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.ReadDTO
{
    public class discountDTO
    {
        public string DiscountType { get; set; } //Affiliate, employee, etc
        public string Percentage { get; set; } //30%, 10%
        public decimal Price { get; set; }
        public string Currency { get; set; } //USD(Dollar) "$"
    }
}
