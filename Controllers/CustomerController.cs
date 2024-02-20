using HR.Application.Service.Abstraction;
using HR.Application.Service.Implementation;
using HR.Application.Service.Models;
using HR.Entity;
//using HR.Infrastructure;
using HR.Model;
using HR.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HR.Controllers
{

    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }

    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerSerivce;
        public CustomersController(ICustomerService customerService)
        {
            _customerSerivce = customerService;
        }


        // GET: api/sample

        [HttpGet]
        [SwaggerOperation(Summary = "Get Customers Info")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAsync()
        {

            var customer = await _customerSerivce.GetCustomers();
            return Ok(customer);
        }
        [SwaggerOperation(Summary = "Insert Customers Info")]
        [HttpPost("insertCustomer")]

        public async Task<IActionResult> MyPostAction(CreateCustomerRequestDto data)
        {

          //  var insertCustomer = await _customerSerivce.InsertCustomer(data);
            ResponseDto<int?> insertCustomer = await _customerSerivce.InsertCustomer(data);



            //var responseData = new ApiResponse
            //{
            //    Success = true,
            //    Message = "Successfully processed the data.",
            //    Data = customer.Id
            //};



            return Ok(insertCustomer);
        }
        [SwaggerOperation(Summary = "Delete Customers Info")]
        [HttpDelete("deleteCustomer")]
        public async Task<IActionResult> Delete(int id)
        {
            ResponseDto<int?> customerDelete = await _customerSerivce.CustomerDelete(id);


            return Ok(customerDelete);

          
        }
    
}
}
