using MediatR;
using Resort.Application.Facebooks.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Facebooks.Queries
{
    public class FacebookQuery: IRequest<IEnumerable<FacebookModel>>
    {
        
    }
}
