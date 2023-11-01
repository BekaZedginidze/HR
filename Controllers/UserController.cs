using HR.Entity;
using HR.Infrastructure;
using HR.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;


using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace HR.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly HrDbContext hrDbContext;
        public UserController(HrDbContext hrDbContext)
        {
            this.hrDbContext = hrDbContext;
        }

        private readonly List<UserRegistration> registeredUsers = new List<UserRegistration>();

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(UserRegistration model)
        {
        //    if (registeredUsers.Any(u => u.Id == model.Id))
          //  {
            //    return Conflict("User with the provided ID already exists.");
           // }

            if (model.Password != model.RePassword)
            {
                return BadRequest("Passwords do not match.");
            }


            var user = new Registration()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                RePassword = model.RePassword,
                Email = model.Email,
                
            };

            var response = hrDbContext.Registration.Add(user);

            hrDbContext.SaveChanges();

            var responseData = new ApiResponse
            {
                Success = true,
                Message = "Successfully Registered",
                Data = user.Id
            };

            return Ok(responseData);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login(UserLogin model)
        {
            var user = hrDbContext.Registration.SingleOrDefault(u => u.Email == model.Email);

            if (user == null || user.Password != model.Password)
            {
                return Unauthorized("Invalid email or password.");
            }

            var token = GenerateJwtToken(user);

            return Ok(new { Token = token });
        }

        private string GenerateJwtToken(Registration user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyForJWTTokenGeneration"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                // Add more claims as needed for authorization purposes
            };
            var expirationTime = DateTime.UtcNow.AddHours(1); // For example, setting the expiration to 1 hour from now


            var token = new JwtSecurityToken(
                
                issuer: "HR",
                audience: "YourAudience",
                claims: claims,
                expires: expirationTime,
                signingCredentials: credentials
            );
            var tokenHandler = new JwtSecurityTokenHandler();


            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

          //  return "test";
        }
    }
      
    
}
