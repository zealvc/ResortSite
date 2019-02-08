using MediatR;
using Resort.Application.Instagrams.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Instagrams.Queries
{
    public class InstaQuery : IRequest<IEnumerable<InstaModel>>
    {
    }
}
