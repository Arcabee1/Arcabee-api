using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Arcabee.Infra.Usuarios.Mapeamentos;

namespace Arcabee.Ioc.Configuracoes;

internal static class ConfiguracoesNhibernate
{
    public static IServiceCollection AddNHibernate(this IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
    {
        services.AddSingleton<ISessionFactory>(factory =>
        {
            return Fluently.Configure().Database(() =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");

                return MySQLConfiguration.Standard
                        .FormatSql()
                        .ShowSql()
                        .ConnectionString(connectionString);
            })
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UsuarioMap>())
               .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
               .BuildSessionFactory();
        });

        services.AddScoped<ISession>(factory =>
        {
            return factory.GetService<ISessionFactory>().OpenSession();
            
        });

        return services;
    }
}
