using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopRUs_API.Helpers;
using ShopRUs_API.Helpers.ReadDTO;
using ShopRUs_API.Helpers.WriteDTO;
using ShopRUs_API.ShopRu.DataAccess.Entities;
using ShopRUs_API.ShopRu.DataAccess.Interface;

namespace ShopRUs_API.Controllers
{
    [ApiController]
    [Route("api/Discount")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger<DiscountController> _logger;
        private readonly IDiscount _discount;

        public DiscountController(ILogger<DiscountController> logger, IDiscount discount)
        {
            _logger = logger;
            _discount = discount;
        }

        [HttpGet("getListOfAllDiscounts")] 
        public IActionResult GetListOfAllDiscounts()  
        {
            try
            {
                _logger.LogInformation("getListOfAllDiscounts");
                var listOfDiscounts = _discount.GetListOfAllDiscounts();
                var listOfDiscounts_ReadDTO = listOfDiscounts
                    .Select(x => new discountDTO
                    {
                       DiscountType = x.DiscountType,
                       Percentage = x.percentage.percentage.ToString() + "%",
                       Price = x.Price
                    }).ToList();

                return Ok(new APIGenericResponseDTO<discountDTO>
                {
                    Success = true,
                    Message = "List Of Discounts",
                    Results = listOfDiscounts_ReadDTO
                });
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = false,
                    Message = "Something went wrong Please try again"
                });
            }
        }

        [HttpGet("getSingleDiscountPercentage{type}")] //by type = discountType
        public IActionResult GetSingleDiscountPercentageByType(string type)   
        {
            try 
            {
                _logger.LogInformation("getSingleDiscountPercentage");
                var singleDiscount = _discount.GetSingleDiscountByType(type);
                if(singleDiscount == null)
                {
                     return NotFound(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = "Discount percentage Not Found, Invalid type passed"
                    });
                }

                var singleDiscountt = new discountDTO
                {
                    Percentage = singleDiscount.percentage.percentage.ToString() + "%",
                    Price = singleDiscount.Price
                };

                return Ok(new APIGenericResponseDTO<discountDTO>
                {
                    Success = true,
                    Message = "Discount Percentage ",
                    Result = singleDiscountt // percentage Type
                });
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = false,
                    Message = "Something went wrong Please try again"
                });
            }
        }

        [HttpPost("CreateDiscountType")]
        public IActionResult CreateDiscountType([FromBody] discountDTOW model)
        {
            try { 
                _logger.LogInformation("createDiscountType");
                StringBuilder strbld = new StringBuilder();
                var err = new List<string>();
                if(!ModelState.IsValid)
                {
                    foreach (var state in ModelState){
                        foreach (var error in state.Value.Errors)
                        {
                            err.Add(error.ErrorMessage);
                            err.ForEach(err => {strbld.AppendFormat(".{0}", error.ErrorMessage); });

                        }
                    }
                    return BadRequest(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = strbld.ToString()
                    });
                }
                //get percentage 
                var percentt = _discount.GetPercentage(model.Percentage);

                var percentg = (percentt.percentage) / 100;
                //var percent = model.Percentage.ToString() + "%";
                var newDiscountType = new Discount
                {
                    DiscountType = model.DiscountType,
                    Currency = model.Currency,
                    PercentageId = model.Percentage, 
                    Price = percentg
                };

                _discount.AddDiscount(newDiscountType);

                _discount.Save();

                _logger.LogInformation("Discount Type Created sucessfully");
                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "Discount Type Created sucessfully"
                });
            }
            catch(Exception ex)
            {
                  _logger.LogError(ex.Message);
                    return Ok(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = "Something went wrong Please try again"
                    });
            }
        }

    }
}