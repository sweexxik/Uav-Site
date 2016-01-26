using System;
using System.Threading.Tasks;
using UAV.Domain.DbContext;
using UAV.Domain.Interfaces;

namespace UAV.Domain.Repositories
{
    /// <summary>
    /// Репозиторий для инкапсулирования логики работы с БД.
    /// Гарантирует использование всеми репозиториями одного контекста данных
    /// </summary>
    public class EfUnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly UavDbContext _db;
        private IUavRepository _uavRepository;
        private IUavTypeRepository _uavTypeRepository;
        private IPayloadRepository _payloadRepository;
        private IGcuTypeRepository _gcuTypeRepository;

        public EfUnitOfWork(string connectionString)
        {
            _db = new UavDbContext(connectionString);
        }
        
        public IUavRepository Uavs => _uavRepository ?? (_uavRepository = new UavRepository(_db));
        public IPayloadRepository Payloads => _payloadRepository ?? (_payloadRepository = new PayloadRepository(_db));
        public IGcuTypeRepository Gcus => _gcuTypeRepository ?? (_gcuTypeRepository = new GcuTypeRepository(_db));
        public IUavTypeRepository UavTypes => _uavTypeRepository ?? (_uavTypeRepository = new UavTypeRepository(_db));

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;

            }
            catch
            {
                return false;
            }
        }
        
        public virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;

            if (disposing)
                _db.Dispose();

            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
