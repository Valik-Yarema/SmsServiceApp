using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interface
{
    interface IUnitOfWork : IDisposable
    {
        void Save();
      
    }
}
