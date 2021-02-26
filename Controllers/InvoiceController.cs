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
    [Route("api/Invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger _logger; 

        public InvoiceController(ILogger logger)
        {
            _logger = logger; 
        }


        [HttpGet("getListOfAllInvoices")] 
        public IActionResult GetListOfInvoices()  
        {
            try
            {
                _logger.LogInformation("getListOfAllInvoices");

                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "List Of Invoices"
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