using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.CrossCuting.IoC
{
    public class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            registerData(services);
        }

        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.StoreDataContext>();
            services.AddTransient<Domain.Contracts.Infra.Data.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            
            services.AddTransient<Domain.Contracts.Repositories.IProdutoReadRepository, Data.EF.Repositories.ProdutoReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IProdutoWriteRepository, Data.EF.Repositories.ProdutoWriteRepositoryEF>();
        }
    }
}
