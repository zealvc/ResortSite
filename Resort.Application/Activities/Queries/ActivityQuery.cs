using MediatR;
using Resort.Application.Activities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Activities.Queries
{
    public class ActivityQuery : IRequest<IEnumerable<ActivityModel>>
    {
    }
}
