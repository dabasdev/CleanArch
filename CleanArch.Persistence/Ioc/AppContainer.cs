using System.Reflection;
using CleanArch.Application.Contracts;
using CleanArch.Application.Mapping;
using CleanArch.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Persistence.Ioc;

public static class AppContainer
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddAutoMapper(expression => expression.AddProfile(typeof(AutoMapperProfile)));
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());


        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("PostConnectionString")));

        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(IPostRepository), typeof(PostRepository));

        return services;
    }
}