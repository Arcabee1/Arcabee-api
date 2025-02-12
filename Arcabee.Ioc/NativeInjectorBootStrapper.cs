using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Arcabee.Ioc.Configuracoes;


namespace Arcabee.Ioc;

public class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services, IConfiguration configuration, IHostEnvironment env)
    {
        services.AddNHibernate(configuration, env);
        services.AddInterfaces();
        
    }

}

