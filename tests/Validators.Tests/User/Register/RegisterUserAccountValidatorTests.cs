using CommonTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace Validators.Tests.User.Register;

public class RegisterUserAccountValidatorTests
{
    [Fact]
    public void Success()
    {
        //Arange(Criar instâncias) 
        var request = RequestRegisterUserAccountJsonBuilder.Build();

        var validator = new RegisterUserAccountValidator();

        //Act(Validar)
        var result = validator.Validate(request);

        //Assert(Verificar se o resultado é válido)
        Assert.True(result.IsValid);
    }
}
