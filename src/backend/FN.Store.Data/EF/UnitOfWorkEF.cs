using FN.Store.Domain.Contracts.Infra.Data;
using System;
using System.Threading.Tasks;

namespace FN.Store.Data.EF
{
    public class UnitOfWorkEF : IUnitOfWork
    {
        private readonly StoreDataContext _ctx;
        public UnitOfWorkEF(StoreDataContext ctx) => _ctx = ctx;

        public async Task CommitAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public Task RollBackAsync()
        {
            throw new NotImplementedException();
        }
    }
}
