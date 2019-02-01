using Microsoft.AspNetCore.Mvc;
using Resort.Application.Activities.Commands;
using Resort.Application.Activities.Models;
using Resort.Application.Activities.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resort.WebUI.Controllers
{
    public class ActivitiesController : BaseController
    {
        [HttpGet]
        public Task<IEnumerable<ActivityModel>> GetActivities()
        {
            return Mediator.Send(new ActivityQuery());
        }
        [HttpPost]
        public IActionResult ChangeActivities(ChangeActivityCommand command)
        {
            Mediator.Send(command);
            return NoContent();
        }
    }
}
