using FN.Store.Domain.Contracts.Infra.Data;
using FN.Store.Domain.Entities;

namespace FN.Store.Domain.Contracts.Repositories
{
    public interface IProdutoReadRepository : IReadRepository<Produto>, IPaginationEF<Produto>
    { }

    public interface IProdutoWriteRepository : IWriteRepository<Produto>
    { }
}
