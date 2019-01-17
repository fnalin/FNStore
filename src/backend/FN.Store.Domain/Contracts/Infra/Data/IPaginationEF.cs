using FN.Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Infra.Data
{

    // www.janholinka.net/Blog/Article/9
    public interface IPaginationEF<TEntity> where TEntity : Entity
    {
        int Total { get; }
        Task<IEnumerable<TEntity>> GetAsync(int skip, int take, Expression<Func<TEntity, bool>> filter = null);

        Task<IEnumerable<TEntity>> GetAsync(int skip, int take,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
    }
}
