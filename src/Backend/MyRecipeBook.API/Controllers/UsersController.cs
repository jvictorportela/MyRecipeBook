using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.UseCases.User.Register;
using MyRecipeBook.Communication.Requests;

namespace MyRecipeBook.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody]RequestRegisterUserAccountJson request)
    {
        var useCase = new RegisterUserAccountUseCase();

        useCase.Execute(request);

        return Created();
    }
}