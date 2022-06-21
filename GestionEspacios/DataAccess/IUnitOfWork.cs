using Entities.Entity_F;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUnitOfWork : IDisposable
    {
        DataBaseContext Context { get; }
        void Commit();

    }
}
