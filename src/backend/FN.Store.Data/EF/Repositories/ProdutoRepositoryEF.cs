using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FN.Store.Domain.Contracts.Infra.Data;
using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoReadRepositoryEF : ReadRepositoryEF<Produto>, IProdutoReadRepository
    {
        public ProdutoReadRepositoryEF(StoreDataContext ctx) : base(ctx) { }

        public int Total { get; private set; }

        public async Task<IEnumerable<Produto>> GetAsync(int skip, int take, Expression<Func<Produto, bool>> filter = null)
        {
            var query = _ctx.Produtos.AsQueryable();

            if (filter != null) query = query.Where(filter);

            Total = query.Count();

            if (Total == 0) return null;

            return await  query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetAsync(
                    int skip, int take, Expression<Func<Produto, bool>> filter = null,
                    Func<IQueryable<Produto>, IOrderedQueryable<Produto>> orderBy = null, params Expression<Func<Produto, object>>[] includes)
        {
            IQueryable<Produto> query = _ctx.Produtos;

            foreach (Expression<Func<Produto, object>> include in includes)
                query = query.Include(include);

            if (filter != null) query = query.Where(filter);

            Total = query.Count();

            if (Total == 0) return null;

            return await query.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        }
    }

    public class ProdutoWriteRepositoryEF : WriteRepositoryEF<Produto>, IProdutoWriteRepository
    {
        public ProdutoWriteRepositoryEF(StoreDataContext ctx) : base(ctx) { }
    }
}
