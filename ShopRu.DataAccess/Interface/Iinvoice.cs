using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopRUs_API.ShopRu.DataAccess.Entities;

namespace ShopRUs_API.ShopRu.DataAccess.Interface
{
   public interface Iinvoice
   {
      void AddInvoice(Invoice invoice);
      Invoice GetSingleInvoiceByInvoiceNumber(string InvoiceNumber);
      
      Task<bool> Save();
   }
}
