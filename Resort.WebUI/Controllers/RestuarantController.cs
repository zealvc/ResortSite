using Microsoft.AspNetCore.Mvc;
using Resort.Application.Restuarants.Commands;
using Resort.Application.Restuarants.Models;
using Resort.Application.Restuarants.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resort.WebUI.Controllers
{
    public class RestuarantController: BaseController
    {
        [HttpGet]

        public Task<IEnumerable<RestuarantModel>> GetAccommodation()

        {

            return Mediator.Send(new RestuarantQuery());
        }

        [HttpPost]
        public IActionResult ChangeRestuarant(ChangeRestuarantCommand command)
        {
            Mediator.Send(command);

            return NoContent();
        }
    }
}
