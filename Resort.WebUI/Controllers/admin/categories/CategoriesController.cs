using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodation.Models;
using Resort.Application.Category.Category.Commands;
using Resort.Application.Category.Category.Queries;
using System.ComponentModel.DataAnnotations;

namespace Resort.WebUI.Controllers.admin.accommodations
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        // GET: api/Categories
        [HttpGet]
        public List<Resort.Domain.Entities.Category> Get()
        {
            GetCategory cat = new GetCategory();
            return cat.GetAll();
        }

        // GET: api/Categories/5
        [HttpGet("{id}", Name = "Categories")]
        public Resort.Domain.Entities.Category Get([Required] int id)
        {
            GetCategory cat = new GetCategory();
            return cat.GetOne(id);
        }

        // POST: api/Categories
        [HttpPost]
        public void Post([FromForm] CategoryModel categoryModel)
        {
            CreateCategory category = new CreateCategory();
            String ret = category.Create(categoryModel);
        }

        /*
        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            CreateCategory category = new CreateCategory();
            category.Delete(id);
        }
    }
}
