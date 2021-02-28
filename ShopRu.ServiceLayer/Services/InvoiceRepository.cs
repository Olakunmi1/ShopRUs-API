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
    public class InvoiceRepository : Iinvoice
    {
        private readonly ApplicationDbContext _context;

        public InvoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice); 
        }
        public Invoice GetSingleInvoiceByInvoiceNumber(string InvoiceNumber)
        {
            var invoicee = _context.Invoices.FirstOrDefault(x => x.InvoiceNumber == InvoiceNumber);

            return invoicee;
        }

        public async Task<bool> Save()
        {
            return  (await _context.SaveChangesAsync() >= 0);

        }
    }
}
