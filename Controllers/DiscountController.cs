using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopRUs_API.Helpers;

namespace ShopRUs_API.Controllers
{
    [ApiController]
    [Route("api/Discount")]
    public class DiscountController : ControllerBase
    {
        private readonly ILogger _logger; 

        public DiscountController(ILogger logger)
        {
            _logger = logger; 
        }

        [HttpGet("getListOfAllDiscounts")] 
        public IActionResult GetListOfAllDiscounts()  
        {
            try
            {
                _logger.LogInformation("getListOfAllDiscounts");

                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "List Of Discounts"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception", ex.Message);
                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = false,
                    Message = "Something went wrong Please try again"
                });
            }
        }
    }
}