using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.Helpers.WriteDTO
{
    public class customersDTOW
    {
        [Required]     
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        public string gender { get; set; }
        [Required]
        public string Address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int typeOfCustomerId { get; set; }
        
    }
}
