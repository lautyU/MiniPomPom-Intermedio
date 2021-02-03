using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceListNumber.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceListNumberController : ControllerBase
    {
        // GET: api/<ServiceListNumberController>

        [HttpGet("basic/list")]
        public IActionResult Getbybasic()
        {

            var Randomlist = new generateRandom();

            return Ok("Lista de numeros aleatoria generado por basic " + Randomlist);

        }
        [HttpGet("jwt/list")]
        public IActionResult GetbyJwt()
        {
            var Randomlist = new generateRandom();

            return Ok("Lista de numeros aleatoria generado por JWT" + Randomlist);
        }
        // POST api/<ServiceListNumberController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ServiceListNumberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ServiceListNumberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
