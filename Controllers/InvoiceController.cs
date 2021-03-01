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
    [Route("api/Invoice")]
    public class InvoiceController : ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly Iinvoice _invoice;
        private readonly ICustomer _customer;
        private readonly IDiscount _discount;

        public InvoiceController(ILogger<InvoiceController> logger, Iinvoice invoice, ICustomer customer, IDiscount discount)
        {
            _logger = logger;
            _invoice = invoice;
            _customer = customer;
            _discount = discount;
        }


        [HttpGet("getListOfAllInvoices/{number}")] 
        public IActionResult GetInvoiceByInvoiceNumber(string number)  
        {
            try
            {
                _logger.LogInformation("getInvoice");
                var invoice = _invoice.GetSingleInvoiceByInvoiceNumber(number);
                if(invoice == null)
                {
                    return NotFound(new APIGenericResponseDTO<string>
                    {
                        Success = true,
                        Message = "Invoice Not Found"
                    });
                }
                var singleInvoice = new InvoiceDTO
                {
                    ClientAddress = invoice.ClientAddress,
                    TotalBill = invoice.TotalBill,
                    InvoiceNumber = invoice.InvoiceNumber,
                    Discount = invoice.Discount,
                    DiscountedPrice = invoice.DiscountedPrice
                };

                return Ok(new APIGenericResponseDTO<InvoiceDTO>
                {
                    Success = true,
                    Message = "Single Invoice By InvoiceNumber",
                    Result = singleInvoice
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

        // Process A bill for A customer and create an Invoice
        //
        [HttpPost("ProcessCustomerBill")]
        public IActionResult ProcessCustomerBill([FromBody] BillProcessDTOW model)
        {
            try { 
                _logger.LogInformation("AboutToProcessCustomerBill");
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
                    _logger.LogInformation("BadRequest");
                    return BadRequest(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = strbld.ToString()
                    });
                }
                var InvoiceNumberr = Guid.NewGuid().ToString();  // further refactor this, to get from storedProcedure

                //single customer Record
                var customerRecord = _customer.GetSingleCustomerByName(model.cuustomerFirstName);
                if(customerRecord == null)
                {
                      _logger.LogInformation("BadRequest");
                    return NotFound(new APIGenericResponseDTO<string>
                    {
                        Success = false,
                        Message = "Customer Record NotFound "
                    });
                }
                if(customerRecord.typeOfCustomer.Type == "Ordinary")
                {
                    //process Bill, Do Total Bill calc
                    if(model.TotalBill < 100) //if true, process bill without any discount
                    {
                            var newInvoicee = new Invoice
                            {
                                ClientAddress = customerRecord.Address,
                                typeOfCustomerId = customerRecord.typeOfCustomer.Id,
                                InvoiceNumber = InvoiceNumberr,
                                TotalBill = model.TotalBill,
                                Discount = 0.0m,
                                Tax = 0.0m,
                                DiscountedPrice = model.TotalBill,
                                Created_at = DateTime.Now,
                                Updated_at = DateTime.Now
                            };

                            _invoice.AddInvoice(newInvoicee);

                            _invoice.Save();
                            _logger.LogInformation("Invoice created");

                            return Ok(new APIGenericResponseDTO<string>
                            {
                                Success = true,
                                Message = "Bil Process Succesful"
                            });
                    }
                            int CustomerDiscount = 5;  // for every $100 bill, customer gets $5 discount

                            var valuee = (model.TotalBill) / 100;
                            int new_value = Convert.ToInt32(valuee);
                            int val_new = (new_value * CustomerDiscount); //for every $100 bill, customer gets $5 discount

                            var priceToPay = model.TotalBill - val_new;

                            var newInvoice_2 = new Invoice
                            {
                                ClientAddress = customerRecord.Address,
                                typeOfCustomerId = customerRecord.typeOfCustomer.Id,
                                InvoiceNumber = InvoiceNumberr,
                                TotalBill = model.TotalBill,
                                Discount = CustomerDiscount,
                                Tax = 0.0m,
                                DiscountedPrice = priceToPay,
                                Created_at = DateTime.Now,
                                Updated_at = DateTime.Now
                            };

                                _invoice.AddInvoice(newInvoice_2);

                                _invoice.Save();
                                _logger.LogInformation("Invoice created");

                                return Ok(new APIGenericResponseDTO<string>
                                {
                                    Success = true,
                                    Message = "Bil Process Succesful"
                                });
                }


                //get customers Discount
                var customerDiscountt = _discount.GetSingleDiscountByType(customerRecord.typeOfCustomer.Type);
                var new_val = (customerDiscountt.Price * model.TotalBill);

                var Price_To_Pay = (model.TotalBill - new_val); //discounted price

                var newInvoice = new Invoice
                {
                    ClientAddress = customerRecord.Address,
                    typeOfCustomerId = customerRecord.typeOfCustomer.Id,
                    InvoiceNumber = InvoiceNumberr,
                    TotalBill = model.TotalBill,
                    Percentage = customerDiscountt.percentage.percentage.ToString() +  "%",
                    Discount = customerDiscountt.Price,
                    Tax = 0.0m,
                    DiscountedPrice = Price_To_Pay,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };

                _invoice.AddInvoice(newInvoice);

                _invoice.Save();

                _logger.LogInformation("Invoice Created sucessfully");

                return Ok(new APIGenericResponseDTO<string>
                {
                    Success = true,
                    Message = "Invoice Created sucessfully"
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