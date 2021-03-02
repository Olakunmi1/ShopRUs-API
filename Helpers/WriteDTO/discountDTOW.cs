using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.WriteDTO
{
    public class discountDTOW 
    {
        [Required]
        public string DiscountType { get; set; } //Affiliate, employee, etc
        [Required]
        public int Percentage { get; set; } //30%, 10%, 5% -- predefined 

        public string Currency { get; set; } //USD(Dollar) "$"
    }
}
