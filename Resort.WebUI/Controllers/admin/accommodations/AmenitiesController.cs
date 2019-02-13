using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.Amenities.Commands;
using Resort.Application.Accommodations.Amenities.Models;
using Resort.Application.Accommodations.Amenities.Queries;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        // GET: api/Amenities
        [HttpGet]
        public List<Resort.Domain.Entities.Amenity> Get()
        {
            GetAmenity cat = new GetAmenity();
            return cat.GetAll();
        }

        // GET: api/Amenities/5
        [HttpGet("{id}", Name = "Amenities")]
        public Resort.Domain.Entities.Amenity Get([Required] int id)
        {
            GetAmenity cat = new GetAmenity();
            return cat.GetOne(id);
        }

        // POST: api/Amenities
        [HttpPost]
        public void Post([FromForm] AmenityModel amenities)
        {
            CDEAmenities cDE = new CDEAmenities();
            string ret = cDE.Create(amenities);
        }

        /*
        // PUT: api/Amenities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CDEAmenities cDE = new CDEAmenities();
            cDE.Delete(id);
        }
    }
}
