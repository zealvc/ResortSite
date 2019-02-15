using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resort.WebUI.Controllers.admin.restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTypeController : ControllerBase
    {
        // GET: api/RestaurantType
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RestaurantType/5
        [HttpGet("{id}", Name = "Restaurant Type")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RestaurantType
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/RestaurantType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
