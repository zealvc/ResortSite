using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.Type.Commands;
using Resort.Application.Accommodations.Type.Models;
using Resort.Application.Accommodations.Type.Queries;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationTypeController : ControllerBase
    {
        // GET: api/AccommodationType
        [HttpGet]
        public List<Resort.Domain.Entities.AccommodationType> Get()
        {
            GetAccomodationType cat = new GetAccomodationType();
            return cat.GetAll();
        }

        // GET: api/AccommodationType/5
        [HttpGet("{id}", Name = "Accommodation Type")]
        public Resort.Domain.Entities.AccommodationType Get([Required] int id)
        {
            GetAccomodationType cat = new GetAccomodationType();
            return cat.GetOne(id);
        }

        // POST: api/AccommodationType
        [HttpPost]
        public void Post([FromForm] AccommodationTypeModel typeModel)
        {
            CDEAccommodationType cDE = new CDEAccommodationType();
            string ret = cDE.Create(typeModel);
        }

        /*
        // PUT: api/AccommodationType/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDEAccommodationType cDE = new CDEAccommodationType();
            cDE.Delete(id);
        }
    }
}
