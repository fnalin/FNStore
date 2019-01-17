using System.Threading.Tasks;

namespace FN.Store.Domain.Contracts.Infra.Data
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RollBackAsync();
    }
}
