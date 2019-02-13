using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.HouseRule.Commands;
using Resort.Application.Accommodations.HouseRule.Models;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseRuleController : ControllerBase
    {
        // GET: api/HouseRule
        [HttpGet]
        public List<Resort.Domain.Entities.HouseRule> Get()
        {
            CDEHouseRule cat = new CDEHouseRule();
            return cat.GetAll();
        }

        // GET: api/HouseRule/5
        [HttpGet("{id}", Name = "HouseRule")]
        public Resort.Domain.Entities.HouseRule Get([Required] int id)
        {
            CDEHouseRule cat = new CDEHouseRule();
            return cat.GetOne(id);
        }

        // POST: api/HouseRule
        [HttpPost]
        public void Post([FromForm] HouseRule_Model houseRule)
        {
            CDEHouseRule cDE = new CDEHouseRule();
            string ret = cDE.Create(houseRule);
        }

        /*
        // PUT: api/HouseRule/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDEHouseRule cDE = new CDEHouseRule();
            cDE.Delete(id);
        }
    }
}
