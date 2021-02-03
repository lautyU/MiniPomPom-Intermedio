using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ms_security_token.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


namespace ms_security_token.Controllers
{
   
    [Route("api/Account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly IConfiguration _configuration;
        public AccountController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AccountController(Castle.Core.Configuration.IConfiguration config)
        {
        }

        [Route("Create")]
        [HttpPost]
        public async Task <IActionResult> BuildToken([FromBody]InputBody models)
        {
            var Claims = new[]
            {
               new Claim("Input-Body",JsonConvert.SerializeObject(models)),
               new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };
            var expiration = DateTime.UtcNow.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llave_secreta"]));
            JwtSecurityToken token = new JwtSecurityToken(
                claims: Claims,
                expires: expiration
                );
            return Ok  (new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expiration
            });

        }
        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    
    }
}
