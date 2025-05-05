using Microsoft.OpenApi.Models;
using NHibernate;
using Arcabee.Ioc;
using Arcabee.Aplicacao.Usuarios.Profiles;
using AutoMapper;
using Arcabee.Aplicacao.Produtos.Profiles;

public partial class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
        builder.Services.AddCors(options =>
                                 {
                                     options.AddPolicy("CorsPolicy",
                                         policy =>
                                         {
                                             policy.WithOrigins("http://0.0.0.0:8080")
                                                 .AllowAnyMethod()
                                                 .AllowAnyHeader()
                                                 .AllowCredentials();
                                         });
                                 });
        var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";

        builder.WebHost.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(Int32.Parse(port));
        });

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Arcabee.API", Version = "v1" });
        });

        builder.Services.AddScoped(provider =>
           provider.GetRequiredService<ISessionFactory>().OpenSession());

        NativeInjectorBootStrapper.RegisterServices(builder.Services, builder.Configuration, builder.Environment);

        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new UsuariosProfile());
            cfg.AddProfile(new ProdutosProfile());
        });

        IMapper mapper = mapperConfig.CreateMapper();

        builder.Services.AddSingleton(mapper);

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Arcabee.API V1");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
