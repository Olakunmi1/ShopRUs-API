using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.WriteDTO
{
    public class BillProcessDTOW
    {
        [Required]     
        public string cuustomerFirstName { get; set; }

        [Required]
        [DataType("decimal(10 ,3)")]
        public decimal TotalBill { get; set; }
    }
}
