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
using ShopRUs_API.ShopRu.DataAccess.helper;
using ShopRUs_API.ShopRu.DataAccess.Interface;

namespace ShopRUs_API.Controllers
{
    [ApiController]
    [Route("api/Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomer _customer;

        public CustomerController(ILogger<CustomerController> logger, ICustomer customer)
        {
            _logger = logger;
            _customer = customer;
        }

        [HttpGet("getListOfAllCustomers")]
        public IActionResult GetListOfCustomers([FromQuery] getListOfCustomersResourceParameters param)   
        {
            try 
            {
                _logger.LogInformation("getListOfAllCusomers");
                var listOfCustomers = _customer.GetListOfAllCustomers(param);
                var listOfCustomer_ReadDTO = listOfCustomers
                    .Select(x => new customersDTO
                    {
                        Name = x.firstName + " " + x.lastName,
                        gender = x.gender,
                        email = x.email,
                        Address = x.Address,
                        created_at = x.created_at,
                        typeOfCustomer = x.typeOfCustomer.Type
                    }).ToList();

                return Ok(new APIGenericResponseDTO<customersDTO>
                {
                    Success = true,
                    Message = "List Of Customers",
                    Results = listOfCustomer_ReadDTO
                    
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

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] customersDTOW model)
        {
            try { 
                _logger.LogInformation("createCustomer");
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

                var newCustomer = new Customer
                {
                    firstName = model.firstName,
                    lastName = model.lastName,
                    gender = model.gender,
                    email = model.email,
                    Address = model.Address,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now,
                    typeOfCustomerId = 2   //temporary, needs to be dynamic
                };

                _customer.AddCustomer(newCustomer);

                _customer.Save();

                _logger.LogInformation("Customer Created sucessfully");
                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "Customer Created sucessfully"
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

        [HttpGet("getSingleCustomerById/{Id}")]
        public IActionResult GetSingleCustomerById(int Id)   
        {
            try 
            {
                _logger.LogInformation("getSingleCusomerByID");
                var singleCustomer = _customer.GetSingleCustomerById(Id);
                if(singleCustomer == null)
                {
                     return NotFound(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = "Customer Not Found, Invalid Id"
                    });
                }

                var singleCustomerrr = new customersDTO
                {
                    Name = singleCustomer.firstName + " " + singleCustomer.lastName,
                    gender = singleCustomer.gender,
                    Address = singleCustomer.Address,
                    email = singleCustomer.email,
                    typeOfCustomer = singleCustomer.typeOfCustomer.Type

                };

                return Ok(new APIGenericResponseDTO<customersDTO>
                {
                    Success = true,
                    Message = "Single Customer By Id",
                    Result = singleCustomerrr
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

        [HttpGet("getSingleCustomerByName/{name}")] //name = firstName 
        public IActionResult GetSingleCustomerByName(string name)   
        {
            try 
            {
                _logger.LogInformation("getSingleCustomerByName");
                var singleCustomer = _customer.GetSingleCustomerByName(name);
                if(singleCustomer == null)
                {
                     return NotFound(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = "Customer Not Found, Invalid Id"
                    });
                }

                var singleCustomerrr = new customersDTO
                {
                    Name = singleCustomer.firstName + " " + singleCustomer.lastName,
                    gender = singleCustomer.gender,
                    Address = singleCustomer.Address,
                    email = singleCustomer.email,
                    typeOfCustomer = singleCustomer.typeOfCustomer.Type

                };

                return Ok(new APIGenericResponseDTO<customersDTO>
                {
                    Success = true,
                    Message = "Single Customer By Id",
                    Result = singleCustomerrr
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