using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Arcabee.Dominio.Usuarios.Repositorios;
using Arcabee.Infra.Usuarios.Repositorios;
using Arcabee.Dominio.Usuarios.Servicos.Interfaces;
using Arcabee.Aplicacao.Usuarios.Servicos.Interfaces;
using Arcabee.Aplicacao.Usuarios.Servicos;
using Arcabee.Dominio.Usuarios.Servicos;
using Arcabee.Aplicacao.Produtos.Servicos.Interfaces;
using Arcabee.Aplicacao.Produtos.Servicos;
using Arcabee.Dominio.Produtos.Repositorios;
using Arcabee.Infra.Produtos.Repositorios;

namespace Arcabee.Ioc.Configuracoes
{
    internal static class ConfiguracoesInjecoesDependencia
    {
        public static IServiceCollection AddInterfaces(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped<IProdutosAppServicos, ProdutosAppServico>();
            services.AddScoped<IProdutosRepositorio, ProdutosRepositorio>();

            services.AddScoped<IUsuariosAppServico, UsuariosAppServico>();
            services.AddScoped<IUsuariosRepositorio, UsuariosRepositorio>();
            services.AddScoped<IUsuariosServicos, UsuariosServicos>();

            return services;
        }
    }
}