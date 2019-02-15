using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.Accommodation.Models;
using Resort.Application.Accommodations.Accommodation.Commands;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationController : ControllerBase
    {
        // GET: api/Accommodation
        [HttpGet]
        public List<Resort.Domain.Entities.Accommodation> Get()
        {
            CDEAccommodation cat = new CDEAccommodation();
            return cat.GetAll();
        }

        // GET: api/Accommodation/5
        [HttpGet("{id}", Name = "Accommodation")]
        public Resort.Domain.Entities.Accommodation Get([Required] int id)
        {
            CDEAccommodation cat = new CDEAccommodation();
            return cat.GetOne(id);
        }

        // POST: api/Accommodation
        [HttpPost]
        public void Post([FromForm] Accommodation_Model accommodation_Model
            , [FromQuery(Name = "ListAmenityId")]int[] ListAmenityId
            , [FromQuery(Name = "ListHouseRuleId")]int[] ListHouseRuleId)
        {
            CDEAccommodation cDE = new CDEAccommodation();
            string ret = cDE.Create(accommodation_Model,ListAmenityId,ListHouseRuleId);
        }

        /*
        // PUT: api/Accommodation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDEAccommodation cDE = new CDEAccommodation();
            cDE.Delete(id);
        }
    }
}
