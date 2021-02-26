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
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getListOfAllCustomers")]
        public IActionResult GetListOfCustomers()   
        {
            try 
            {
                _logger.LogInformation("getListOfAllCusomers");

                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "List Of Customers"
                });
            }
            catch(Exception ex)
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