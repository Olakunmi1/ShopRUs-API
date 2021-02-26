using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.DataAccess.helper
{
    //This helper class helps with Paging and sorting 
    // Max PerPage = 15, PageNumber = 1 
    public class getListOfCustomersResourceParameters
    {
        const int maxpagesize = 15; 
        public int PageNumber { get; set; } = 1;
        private int _Pagesize { get; set; } = 10;
        public int pageSize
        {
            get => _Pagesize;
            set => _Pagesize = (value > maxpagesize) ? maxpagesize : value;
        }
    }
}
