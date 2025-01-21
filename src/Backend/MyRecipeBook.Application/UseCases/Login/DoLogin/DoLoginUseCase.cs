using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.Login.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IUserReadOnlyRepository _repository;
    private readonly PasswordEncrypter _passwordEncrypter;

    public DoLoginUseCase(IUserReadOnlyRepository repository, PasswordEncrypter passwordEncrypter)
    {
        _repository = repository;
        _passwordEncrypter = passwordEncrypter;
    }

    public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
    {
        var encrypterPassword = _passwordEncrypter.Encrypt(request.Password);

        var user = await _repository.GetByEmailAndPassword(request.Email, encrypterPassword) ?? throw new InvalidLoginException();
        //?? se devolver nulo, executo o que está após.

        return new ResponseRegisteredUserJson
        {
            Name = user.Name
        };
    }
}
