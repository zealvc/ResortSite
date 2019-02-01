using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Application.Restuarants.Commands
{
    public class ChangeRestuarantCommand : IRequest
    {
        public int Id { get; set; }
    }
}
