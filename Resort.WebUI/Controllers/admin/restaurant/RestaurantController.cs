﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Resort.WebUI.Controllers.admin.restaurant
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        // GET: api/Restaurant
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Restaurant/5
        [HttpGet("{id}", Name = "Restaurant")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Restaurant
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Restaurant/5
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
