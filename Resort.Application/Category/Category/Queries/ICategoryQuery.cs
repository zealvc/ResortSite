using System;
using System.Collections.Generic;
using System.Text;
using Resort.Application.Accommodation.Models;
using Resort.Persistence.Repository_and_Unit_of_Work_Interface;

namespace Resort.Application.Accommodation.Queries
{
    public interface ICategoryQuery : IRepository<CategoryModel>
    {

    }
}
