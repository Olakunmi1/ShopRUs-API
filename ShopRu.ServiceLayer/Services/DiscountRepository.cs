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
    public class DiscountRepository : IDiscount
    {
        private readonly ApplicationDbContext _context;

        public DiscountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
        }

        public List<discountDTO> GetListOfAllDiscounts()
        {
            var discounts = _context.Discounts.Include(x => x.percentage);

            var listOfDiscounts_ReadDTO = discounts
                   .Select(x => new discountDTO
                   {
                       DiscountType = x.DiscountType,
                       Percentage = x.percentage.percentage.ToString() + "%",
                       Price = x.Price
                   }).ToList();


            return listOfDiscounts_ReadDTO;
        }

        public Percentage GetPercentage(int percentg)
        {
            var percntt = _context.percentages.FirstOrDefault(x => x.Id == percentg);

            return percntt;
        }

        public Discount GetSingleDiscountByType(string name)
        {
            var discount = _context.Discounts.Include(x => x.percentage)
                                            .FirstOrDefault(x => x.DiscountType == name);

            return discount;
        }

        public async Task<bool> Save()
        {
            return  (await _context.SaveChangesAsync() >= 0);

        }
    }
}
