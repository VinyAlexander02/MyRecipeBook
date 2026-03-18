using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Application.Usecases.User.Register;

namespace MyRecipeBook.Application;
public static class DependencyInjectionExtencion
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
        AddPassWordEncripter(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();
        services.AddScoped(option => autoMapper);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUsecase, RegisterUserUsecase>();
    }

     private static void AddPassWordEncripter(IServiceCollection services)
    {
        services.AddScoped(option => new PasswordEncripter());
    }

}