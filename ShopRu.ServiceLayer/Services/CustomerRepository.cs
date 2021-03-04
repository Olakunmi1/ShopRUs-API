using Microsoft.EntityFrameworkCore;
using ShopRUs_API.Helpers.ReadDTO;
using ShopRUs_API.ShopRu.DataAccess.DBContext;
using ShopRUs_API.ShopRu.DataAccess.Entities;
using ShopRUs_API.ShopRu.DataAccess.helper;
using ShopRUs_API.ShopRu.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopRUs_API.ShopRu.ServiceLayer.Services
{
    public class CustomerRepository : ICustomer
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        //for paging and sorting 
        public List<customersDTO> GetListOfAllCustomers(getListOfCustomersResourceParameters parameters)
        {
            var collections = _context.Customers as IQueryable<Customer>;
            collections = collections.Include(t => t.typeOfCustomer)
                                     .Skip(parameters.pageSize * (parameters.PageNumber - 1))
                                     .Take(parameters.pageSize);
            
            collections.ToList();

            var listOfCustomer_ReadDTO = collections
                   .Select(x => new customersDTO
                   {
                       Name = x.firstName + " " + x.lastName,
                       gender = x.gender,
                       email = x.email,
                       Address = x.Address,
                       created_at = x.created_at,
                       typeOfCustomer = x.typeOfCustomer.Type
                   }).ToList();
            return listOfCustomer_ReadDTO;
        }

        public List<customersDTO> GetListOf_AllCustomers()
        {
            var collections = _context.Customers.Include(t => t.typeOfCustomer);

            var listOfCustomer_ReadDTO = collections
                   .Select(x => new customersDTO
                   {
                       Name = x.firstName + " " + x.lastName,
                       gender = x.gender,
                       email = x.email,
                       Address = x.Address,
                       created_at = x.created_at,
                       typeOfCustomer = x.typeOfCustomer.Type
                   }).ToList();
            return listOfCustomer_ReadDTO;
        }

        public Customer GetSingleCustomerById(int id)
        {
            var singleCustomer = _context.Customers.Include(x => x.typeOfCustomer)
                                                .FirstOrDefault(x => x.Id == id);
            return singleCustomer;
        }

        public Customer GetSingleCustomerByName(string name)
        {
            var singleCustomerByName = _context.Customers.Include(x => x.typeOfCustomer)
                                                    .FirstOrDefault(x => x.firstName == name);

            return singleCustomerByName;
        }

        public async Task<int> Save()
        {
            var response = _context.SaveChangesAsync();
            return await response;
           // return  (await _context.SaveChangesAsync() >= 0);

        }
    }
}
