using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopRUs_API.ShopRu.DataAccess.Entities;

namespace ShopRUs_API.ShopRu.DataAccess.Interface
{
   public interface IDiscount
   {
      IEnumerable<Discount> GetListOfAllDiscounts();
      void AddDiscount(Discount discount);
      Discount GetSingleDiscountByType(string name);

      Percentage GetPercentage(int percentg);

      Task<bool> Save();

   }
}
