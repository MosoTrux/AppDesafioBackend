using AppDesafio.Domain.Entities;
using AppDesafio.Domain.Repositories;
//using AppDesafio.Infrastructure.Data.SqlServer;
using AppDesafio.Infrastructure.Data.InMemory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppDesafio.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly DesafioDBContext _context;
        protected readonly DbSet<T> _entities;

        public BaseRepository(DesafioDBContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return _entities;
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id).ConfigureAwait(false);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove(entity);
        }

        //public async Task DeleteBy(Expression<Func<T, bool>> predicate)
        //{
        //    T entity = await GetBy(predicate).FirstOrDefaultAsync().ConfigureAwait(false);
        //    _entities.Remove(entity);
        //}

        public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }
    }
}
