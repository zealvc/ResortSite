using System;
using System.Collections.Generic;
using System.Text;

namespace Resort.Persistence.Repository_and_Unit_of_Work_Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
