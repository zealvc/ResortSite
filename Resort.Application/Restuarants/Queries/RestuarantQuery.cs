using MediatR;
using Resort.Application.Restuarants.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Restuarants.Queries
{
    public class RestuarantQuery : IRequest<IEnumerable<RestuarantModel>>
    {
    }
}
