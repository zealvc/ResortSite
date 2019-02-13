using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.SleepingArrangement.Models;
using Resort.Application.Accommodations.SleepingArrangement.Commands;
using System.ComponentModel.DataAnnotations;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class SleepingArrangementController : ControllerBase
    {
        // GET: api/SleepingArrangement
        [HttpGet]
        public List<Resort.Domain.Entities.SleepingArrangement> Get()
        {
            CDESleepingArragement cat = new CDESleepingArragement();
            return cat.GetAll();
        }

        // GET: api/SleepingArrangement/5
        [HttpGet("{id}", Name = "SleepingArrangement")]
        public Resort.Domain.Entities.SleepingArrangement Get([Required] int id)
        {
            CDESleepingArragement cat = new CDESleepingArragement();
            return cat.GetOne(id);
        }

        // POST: api/SleepingArrangement
        [HttpPost]
        public void Post([FromForm] SleppingArragement_Model slepping)
        {
            CDESleepingArragement cDE = new CDESleepingArragement();
            string ret = cDE.Create(slepping);
        }

        /*
        // PUT: api/SleepingArrangement/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDESleepingArragement cDE = new CDESleepingArragement();
            cDE.Delete(id);
        }
    }
}
