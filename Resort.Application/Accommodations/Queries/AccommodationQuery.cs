using System.Collections.Generic;
using MediatR;
using Resort.Application.Accommodations.Models;

namespace Resort.Application.Accommodations.Queries
{
    public class AccommodationQuery : IRequest<IEnumerable<AccommodationModel>>
    {
    }
}
