using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Accommodations.Commands
{
    public class ChangeAccommodationComand : IRequest
    {
        public int Id { get; set; }
    }
}
