using Entities.Entity_F;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        public DataBaseContext Context { get; }

        public UnitOfWork(DataBaseContext context)
        {
            Context = context;
        }

        public void Commit()
        {
            Context.SaveChanges();

        }

        public void Dispose()
        { 
            Context.Dispose();  
        }
    }
}
