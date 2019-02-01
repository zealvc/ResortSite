using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resort.Application.Accommodations.Commands;
using Resort.Application.Accommodations.Models;
using Resort.Application.Accommodations.Queries;
namespace Resort.WebUI.Controllers
{
    public class AccommodationController: BaseController
    {
        [HttpGet]

        public Task<IEnumerable<AccommodationModel>> GetAccommodation()

        {

            return Mediator.Send(new AccommodationQuery());
        }

        [HttpPost]
        public IActionResult ChangeAccommodation(ChangeAccommodationComand command)
        {
            Mediator.Send(command);

            return NoContent();
        }
    }
}
