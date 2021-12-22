using AppDesafio.Domain.Entities;
using AppDesafio.Domain.Repositories;
//using AppDesafio.Infrastructure.Data.SqlServer;
using AppDesafio.Infrastructure.Data.InMemory;
using System.Threading.Tasks;

namespace AppDesafio.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DesafioDBContext _context;
        private IBaseRepository<TipoCambio> _tipoCambioRepository;

        public UnitOfWork(DesafioDBContext context)
        {
            _context = context;
        }
        public IBaseRepository<TipoCambio> TipoCambioRepository
        {
            get
            {
                if (_tipoCambioRepository == null)
                    _tipoCambioRepository = new BaseRepository<TipoCambio>(_context);
                return _tipoCambioRepository;
            }
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
