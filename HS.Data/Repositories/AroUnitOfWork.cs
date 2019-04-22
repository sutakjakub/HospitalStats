using HS.Data.Entitites.ARO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HS.Data.Repositories
{
    public class AroUnitOfWork
    {
        private readonly HsDbContext _context = new HsDbContext();
        private readonly GenericRepository<OperationRoomAction> _oRrepository;

        public GenericRepository<OperationRoomAction> OperationRoomRepository
        {
            get
            {
                return this._oRrepository ?? new GenericRepository<OperationRoomAction>(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
