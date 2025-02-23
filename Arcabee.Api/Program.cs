using Microsoft.OpenApi.Models;
using NHibernate;
using Arcabee.Ioc;
using Arcabee.Aplicacao.Usuarios.Profiles;
using AutoMapper;

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
                                            policy.WithOrigins("http://localhost:5249")
                                                .AllowAnyMethod()
                                                .AllowAnyHeader()
                                                .AllowCredentials();
                                        });
                                });
        // Configuração do Swagger
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
