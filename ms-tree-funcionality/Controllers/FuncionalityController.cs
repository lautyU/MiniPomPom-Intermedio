using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ms_tree_funcionality.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ms_tree_funcionality.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class FuncionalityController : ControllerBase
    {
        private readonly JsonActions _JsonActions;
       public readonly IConfiguration _config;

        public FuncionalityController(JsonActions jsonActions, IConfiguration config)
        {
            _JsonActions = jsonActions;
            _config = config;
        }
        // GET: api/<FuncionalityController>
        [HttpGet]

        public  async Task<ActionResult> Get()
        {
            Root data;
            try
            {
               
                data = _JsonActions.Getdata(Environment.GetEnvironmentVariable("JsonDocument"));
                


            }
            catch (FileNotFoundException e)
            {
                throw new Exception("archivo no encontrado" + e);
            }

            return Ok(data);
        }

       

        // POST api/<FuncionalityController>
        [HttpPost]
                // PUT api/<FuncionalityController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FuncionalityController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
