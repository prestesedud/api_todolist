using api_todolist.Application.Config;
using api_todolist.Infra.Interfaces;
using api_todolist.Infra.Repositories;
//using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using api_todolist.Application.Config;
//using api_todolist.Application.Interfaces;
//using api_todolist.Application.Services;
//using api_todolist.Core.Token;
using api_todolist.Infra.Interfaces;
using api_todolist.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyScope.Ioc
{
    public static class Injection
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services, MigrationConfig? migrationConfig)
        {
            //if (migrationConfig != null && migrationConfig.AplicarMigration == true)
            //{
            //    using (var scope = services.BuildServiceProvider().CreateScope())
            //    {
            //        var dbContext = scope.ServiceProvider.GetRequiredService<SantoAndreContext>();
            //        dbContext.Database.Migrate();
            //    }
            //}

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IBaseRelationRepository<>), typeof(BaseRelationRepository<>));
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            //Services
            //services.AddScoped(typeof(IAuthService), typeof(AuthService));
            //services.AddScoped(typeof(TokenConfigurations));

            return services;
        }
    }
}
