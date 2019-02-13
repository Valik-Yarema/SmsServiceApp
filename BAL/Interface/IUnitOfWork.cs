using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Interface
{
     public interface IUnitOfWork : IDisposable
    {
        void Save();
      
    }
}
