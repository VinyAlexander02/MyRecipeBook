using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Infra.DataAccess;
using MyRecipeBook.Infra.DataAccess.Repositories;

namespace MyRecipeBook.Infra;
public static class DependencyInjectionExtencion
{
    public static void AddInfra(this IServiceCollection services)
    {
        AddRepositories(services);
        AddDbContext_SqlServer(services);
    }

    private static void AddDbContext_SqlServer(IServiceCollection services)
    {
        var connectionString = "";
        services.AddDbContext<MyRecipeBookDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
     services.AddScoped<IUserWriteOnlyRepository, UserRepository>();   
     services.AddScoped<IUserReadOnlyRepository, UserRepository>();   
    }
}