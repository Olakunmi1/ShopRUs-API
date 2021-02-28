using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.Entities
{
    public class Percentage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int percentage { get; set; }
        [Required]
        public string Comment { get; set; }
        public DateTime Created_at { get; set; }
    }
}
