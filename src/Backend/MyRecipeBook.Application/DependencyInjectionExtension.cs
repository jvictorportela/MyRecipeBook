using Microsoft.Extensions.DependencyInjection;
using MyRecipeBook.Application.UseCases.User.Register;

namespace MyRecipeBook.Application;

public class DependencyInjectionExtension
{
    public void AddApplication(IServiceCollection services)
    {
        AddUsecases(services);
    }

    private void AddUsecases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserAccountUseCase, RegisterUserAccountUseCase>();
    }
}