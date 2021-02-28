using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.Entities
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientAddress { get; set; }

        [ForeignKey("typeOfCustomerId")]
        public TypeOfCustomer typeOfCustomer { get; set; }
        public int typeOfCustomerId { get; set; }
        
        [Required]
        public string InvoiceNumber { get; set; }

        [DataType("decimal(20 ,4)")]
        public decimal TotalBill { get; set; }

        [DataType("decimal(10 ,3)")]
        public decimal Discount { get; set; }
        //public decimal DiscountedPrice { get; set; } //price after discount has been applied
        public string Percentage { get; set; } 
        
        [DataType("decimal(10,3)")]
        public decimal? Tax { get; set; }

        [DataType("decimal(10 ,3)")]
        public decimal DiscountedPrice { get; set; } //price after discount has been applied, also TotalPrice
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

    }
}
