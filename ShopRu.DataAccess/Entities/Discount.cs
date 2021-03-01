using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.Entities
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DiscountType { get; set; } //Affiliate, employee, etc

        [ForeignKey("PercentageId")]
        public Percentage percentage { get; set; }

        public int PercentageId { get; set; } //30%, 10%

        [DataType("decimal(10 ,3)")]
        public decimal Price { get; set; }
        public string Currency { get; set; } //USD(Dollar) "$"

    }
}
