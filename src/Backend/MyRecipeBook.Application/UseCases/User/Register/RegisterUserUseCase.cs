using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExceptionsBase;

namespace MyRecipeBook.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeRepository;
    private readonly IUserReadOnlyRepository _readRepository;

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        //Validar a request
        Validate(request);

        //Mapear a request em uma entidade
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.User>(request);

        //Criptografar a senha
        var passwordCriptography = new PasswordEncrypter();
        user.Password = passwordCriptography.Encrypt(request.Password);

        //Salvar no banco de dados
        await _writeRepository.Add(user);

        return new ResponseRegisteredUserJson
        {
            Name = request.Name
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorsMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorsMessages);
        }
    }
}
