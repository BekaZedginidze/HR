using HR.Entity;
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
using HR.Application.Service.Abstraction;
using HR.Application.Service.Models;
using static HR.Application.Service.Implementation.CustomerService;

namespace HR.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userSerivce;
        public UserController(IUserService userSerivce)
        {
            _userSerivce = userSerivce;
        }

        private readonly List<UserRegistrationDto> registeredUsers = new List<UserRegistrationDto>();

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Register(UserRegistrationDto model)
        {
            ResponseDto<int?> userId = _userSerivce.UserRegister(model);
           

            var responseData = new ApiResponse
            {
                Success = true,
                Message = "Successfully Registered",
                Data = userId
            };

            return Ok(userId);
        }

      //  private readonly List<UserLoginDto> loginUsers = new List<UserLoginDto>;

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Login(UserLoginDto model)
        {
            string token = _userSerivce.UserLogin(model);
            
            return Ok(new { Token = token });
        }

        //private string GenerateJwtToken(Users user)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyForJWTTokenGeneration"));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new[]
        //    {
        //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //        new Claim(ClaimTypes.Email, user.Email),
        //        // Add more claims as needed for authorization purposes
        //    };
        //    var expirationTime = DateTime.UtcNow.AddHours(1); // For example, setting the expiration to 1 hour from now


        //    var token = new JwtSecurityToken(

        //        issuer: "HR",
        //        audience: "YourAudience",
        //        claims: claims,
        //        expires: expirationTime,
        //        signingCredentials: credentials
        //    );
        //    var tokenHandler = new JwtSecurityTokenHandler();


        //    var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        //    return jwt;

          
    //    }
    }
      
    
}
