using FluentValidation;
using FN.Store.Domain.Mediator;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FN.Store.CrossCuting.IoC
{
    public class Configuration
    {
        public static void RegisterServices(IServiceCollection services)
        {
            registerMediatr(services);
            registerData(services);
            registerAppServices(services);
        }

        private static void registerMediatr(IServiceCollection services)
        {
            const string applicationAssemblyName = "FN.Store.Domain";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));

            services.AddMediatR();
        }


        private static void registerData(IServiceCollection services)
        {
            services.AddScoped<Data.EF.StoreDataContext>();
            services.AddTransient<Domain.Contracts.Infra.Data.IUnitOfWork, Data.EF.UnitOfWorkEF>();

            
            services.AddTransient<Domain.Contracts.Repositories.IProdutoReadRepository, Data.EF.Repositories.ProdutoReadRepositoryEF>();
            services.AddTransient<Domain.Contracts.Repositories.IProdutoWriteRepository, Data.EF.Repositories.ProdutoWriteRepositoryEF>();
        }

        private static void registerAppServices(IServiceCollection services)
        {
            //services.AddTransient<Domain.Contracts.Infra.Service.ISendMail, Services.SendMail>();
        }
    }
}
