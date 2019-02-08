using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Interface;
using Resort.Application.Accommodation.Models;

namespace Resort.Application.Accommodation.Queries
{
    interface AccommodationQuery : IRepository<AccommodationModel>
    {
    }
}
