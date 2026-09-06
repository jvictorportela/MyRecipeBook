using CommonTestUtilities.Requests;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Exception;
using Shouldly;

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
        
        //Assert.True(result.IsValid);
        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenNameIsEmpty()
    {
        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Name = string.Empty;

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(e =>
        {
            e.Count.ShouldBe(1);
            e.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_NAME_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = string.Empty;

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(e =>
        {
            e.Count.ShouldBe(1);
            e.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenPasswordIsEmpty()
    {
        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Password = string.Empty;

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(e =>
        {
            e.Count.ShouldBe(1);
            e.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_PASSWORD_REQUIRED));
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsInvalid()
    {
        // Arrange
        var request = RequestRegisterUserAccountJsonBuilder.Build();
        request.Email = "invalid-email";

        var validator = new RegisterUserAccountValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(e =>
        {
            e.Count.ShouldBe(1);
            e.ShouldContain(error => error.ErrorMessage.Equals(ResourceMessagesException.VALIDATION_IS_VALID_EMAIL));
        });
    }
}