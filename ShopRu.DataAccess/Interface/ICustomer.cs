using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopRUs_API.ShopRu.DataAccess.Entities;
using ShopRUs_API.ShopRu.DataAccess.helper;

namespace ShopRUs_API.ShopRu.DataAccess.Interface
{
   public interface ICustomer
   {
       ///parameter below is to aid Paging and sorting incase of Customer large dataSet
      IEnumerable<Customer> GetListOfAllCustomers(getListOfCustomersResourceParameters parameter); 
      void AddCustomer(Customer customer);
      Customer GetSingleCustomerById(int id);
      Customer GetSingleCustomerByName(string name);
      Task<bool> Save();
   }
}
