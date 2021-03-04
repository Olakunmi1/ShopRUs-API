using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopRUs_API.Helpers.ReadDTO;
using ShopRUs_API.ShopRu.DataAccess.Entities;
using ShopRUs_API.ShopRu.DataAccess.helper;

namespace ShopRUs_API.ShopRu.DataAccess.Interface
{
   public interface ICustomer
   {
       ///parameter below is to aid Paging and sorting incase of Customer large dataSet
      List<customersDTO> GetListOfAllCustomers(getListOfCustomersResourceParameters parameter);
      List<customersDTO> GetListOf_AllCustomers(); 
      void AddCustomer(Customer customer);
      Customer GetSingleCustomerById(int id);
      Customer GetSingleCustomerByName(string name);
      Task<int> Save();
   }
}
