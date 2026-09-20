using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.UseCases.User.Login.WithEmailAndPassword;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUsecases(services);
    }

    private static void AddUsecases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
        services.AddScoped<ILoginWithEmailAndPassword, LoginWithEmailAndPassword>();
    }
}