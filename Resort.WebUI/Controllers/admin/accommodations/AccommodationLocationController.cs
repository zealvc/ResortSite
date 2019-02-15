using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.Location.Queries;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Resort.Application.Accommodations.Location.Commands;
using Resort.Application.Accommodations.Location.Models;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccommodationLocationController : ControllerBase
    {
        // GET: api/AccommodationLocation
        [HttpGet]
        public List<Resort.Domain.Entities.AccommodationLocation> Get()
        {
            GetAccommodationLocation cat = new GetAccommodationLocation();
            return cat.GetAll();
        }

        // GET: api/AccommodationLocation/5
        [HttpGet("{id}", Name = "Accommodation Location")]
        public Resort.Domain.Entities.AccommodationLocation Get([Required] int id)
        {
            GetAccommodationLocation cat = new GetAccommodationLocation();
            return cat.GetOne(id);
        }

        // POST: api/AccommodationLocation
        [HttpPost]
        public void Post([FromForm] AccoLocationModel locationModel)
        {
            CDEAccommodationLocation cDE = new CDEAccommodationLocation();
            string ret = cDE.Create(locationModel);
        }

        /*
        // PUT: api/AccommodationLocation/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDEAccommodationLocation cDE = new CDEAccommodationLocation();
            cDE.Delete(id);
        }
    }
}
