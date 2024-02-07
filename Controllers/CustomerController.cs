//using HR.Entity;
//using HR.Infrastructure;
//using HR.Model;
//using HR.Models;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Swashbuckle.AspNetCore.Annotations;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;

//namespace HR.Controllers
//{

//    public class ApiResponse
//    {
//        public bool Success { get; set; }
//        public string Message { get; set; }
//        public object Data { get; set; }
//    }

//   // [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CustomersController : ControllerBase
//    {

//        private readonly HrDbContext hrDbContext;
//        public CustomersController(HrDbContext hrDbContext)
//        {
//            this.hrDbContext = hrDbContext;
//        }


//        // GET: api/sample

//        [HttpGet]
//        [SwaggerOperation(Summary = "Get Customers Info")]
//        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
//        public async Task<IActionResult> GetAsync()
//        {
//            List<GetCustomer> getCustomer = new List<GetCustomer>();
//            var response = await hrDbContext.Customers
//                .Include(x => x.Gender)
//                .Include(x => x.PhoneNumbers)
//                .ToListAsync();




//            foreach (var item in response)
//            {

//                var phoneNumbers = item.PhoneNumbers.Select(p => new PhoneNumberModel
//                {
//                    PhoneNumber = p.PhoneNumber,
//                    IsDefault = p.IsDefault

//                }).ToList();
//                getCustomer.Add(new GetCustomer()
//                {
//                    Firstname = item.Firstname,
//                    Lastname = item.Lastname,
//                    GenderId = item.GenderId,
//                    GenderName = item.Gender.Name,
//                    DateOfBirth = item.DateOfBirth,
//                    PhoneNumbers = phoneNumbers

//                });
//            }

//            return Ok(getCustomer);
//        }
//        [SwaggerOperation(Summary = "Insert Customers Info")]
//        [HttpPost("insertCustomer")]

//        public async Task<IActionResult> MyPostAction(InsertCustomer data)
//        {



//            var phoneNumber = data.PhoneNumbers.Select(p => new PhoneNumbers
//            {
//                PhoneNumber = p.PhoneNumber,
//                IsDefault = p.IsDefault
//            }).ToList();





//            var customer = new Customer()
//            {
//                Lastname = data.Lastname,
//                GenderId = data.GenderId,
//                DateOfBirth = data.DateOfBirth,
//                Firstname = data.Firstname,
//                PhoneNumbers = phoneNumber,
               
//            };

//            var response = hrDbContext.Customers.Add(customer);

//                hrDbContext.SaveChanges();

//                var responseData = new ApiResponse
//                {
//                    Success = true,
//                    Message = "Successfully processed the data.",
//                    Data = customer.Id
//                };
            
        

//            return Ok(responseData);
//        }
//        [SwaggerOperation(Summary = "Delete Customers Info")]
//        [HttpDelete("deleteCustomer")]
//        public async Task<IActionResult> Delete(int id)
//        {
//            try
//            {
//                var resourceToDelete = await hrDbContext.Customers.FindAsync(id);

//                hrDbContext.Customers.Remove(resourceToDelete);
//                await hrDbContext.SaveChangesAsync();

//                return Ok("Deleted Successfully");
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, "Id not found");
//            }
//        }
//    }
//}
