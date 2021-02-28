using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<Customer> GetListOfAllCustomers(getListOfCustomersResourceParameters parameters)
        {
            var collections = _context.Customers as IQueryable<Customer>;
            collections = collections.Include(t => t.typeOfCustomer)
                                     .Skip(parameters.pageSize * (parameters.PageNumber - 1))
                                     .Take(parameters.pageSize);
            
            collections.ToList();
            return collections;
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

        public async Task<bool> Save()
        {
            return  (await _context.SaveChangesAsync() >= 0);

        }
    }
}
