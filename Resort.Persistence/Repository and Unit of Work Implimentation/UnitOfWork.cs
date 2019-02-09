using Resort.Persistence.Repository_and_Unit_of_Work_Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Resort.Domain;
using Resort.Domain.Entities;

namespace Resort.Persistence.Repository_and_Unit_of_Work_Implimentation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ResortSiteDbContext _context;

        public UnitOfWork(ResortSiteDbContext context)
        {
            _context = context;
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
