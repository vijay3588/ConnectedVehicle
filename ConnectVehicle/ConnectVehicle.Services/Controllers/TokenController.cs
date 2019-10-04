using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectVehicle.Services.Model;
using ConnectVehicle.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ConnectVehicle.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private IConfiguration _config;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        public TokenController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Used to create new JWT token for authentication
        /// </summary>
        /// <param name="login">passing login entity</param>
        /// <returns>return response code 'OK' or 'Not Found'</returns>
        [HttpPost]
        public IActionResult CreateToken([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            Logger.Info("Creating new token through the user. User Name: " + login.UserName);

            var user = Authenticate(login);

            if (user != null)
            {
                Logger.Info("Authenticated successfully. User Name: " + login.UserName);
                var tokenString = BuildToken(user);
                Logger.Info("Toen generated successfully. New Token: " + tokenString);
                response = Ok(new { token = tokenString });
            }

            // Return response
            return response;
        }

        /// <summary>
        /// Used to build token using login user
        /// </summary>
        /// <param name="user">passing user entity</param>
        /// <returns>return JWT token handler</returns>
        private string BuildToken(UserModel user)
        {
            // Reading secret key from config and getting SymmetricSecurityKey
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtAuthentication:SecurityKey"]));
            Logger.Info("Reading secret key from config and getting SymmetricSecurityKey");

            // Signing credential using HmacSha256 algorithm
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            Logger.Info("Signing credential using HmacSha256 algorithm");

            // Generating token using valid issuer, audience & credential
            var token = new JwtSecurityToken(_config["JwtAuthentication:ValidIssuer"],
              _config["JwtAuthentication:ValidAudience"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            // return new token
            Logger.Info("Return new token");
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Used to authenticate user 
        /// </summary>
        /// <param name="login">passing login entity which hold user name and password</param>
        /// <returns>return user model entity after evaluate</returns>
        private UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            // Evaluating user credential
            if (login.UserName == "scania" && login.Password == "secret")
            {
                user = new UserModel { Name = "sacnia vehicle", Email = "scania.vehicle@domain.com" };
            }

            // Return user model after evaluate
            return user;
        }
    }
}