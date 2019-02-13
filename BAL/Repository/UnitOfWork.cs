using BAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebCustomerApp.Data;

namespace BAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _DbContext;
        private bool disposed = false;
        private AddInfoRepository addInfoRepository;

        public UnitOfWork(ApplicationDbContext connectionContext)
        {
            _DbContext = connectionContext;
        }


        #region default Save & Dispose
        public void Save()
        {
            _DbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _DbContext.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
