using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RobotProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ValuesController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IActionResult get()//Enumerable<string> Get()
        {
            return Ok("hello world!");// new string[] { "value1", "value2" };
        }
             
        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(JObject payload) //void Post([FromBody]string value)
        {
            return Ok(payload);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

