using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public abstract class ReadRepositoryEF<TEntity> : IReadRepository<TEntity>
       where TEntity : Entity
    {
        protected readonly StoreDataContext _ctx;
        private readonly DbSet<TEntity> _db;
        public ReadRepositoryEF(StoreDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _db.AsNoTracking().ToList();
        }

        public TEntity Get(int id)
        {
            return _db.AsNoTracking().FirstOrDefault(e => e.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAsync()
        {
            return await _db.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _db.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }
    }

    public abstract class WriteRepositoryEF<TEntity> : IWriteRepository<TEntity>
       where TEntity : Entity
    {
        private readonly StoreDataContext _ctx;
        private readonly DbSet<TEntity> _db;
        public WriteRepositoryEF(StoreDataContext ctx)
        {
            _ctx = ctx;
            _db = _ctx.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _db.Update(entity);
        }
    }
}
