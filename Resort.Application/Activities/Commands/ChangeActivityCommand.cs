using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Activities.Commands
{
    public class ChangeActivityCommand : IRequest
    {
        public int Id { get; set; }
    }
}
