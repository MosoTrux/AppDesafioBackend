using AppDesafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AppDesafio.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TipoCambio> TipoCambioRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
