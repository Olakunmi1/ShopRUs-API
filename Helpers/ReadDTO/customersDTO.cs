using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.ReadDTO
{
    public class customersDTO
    {
        public string Name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string Address { get; set; }
        public DateTime created_at { get; set; }
        public string typeOfCustomer { get; set; }
        
    }
}
