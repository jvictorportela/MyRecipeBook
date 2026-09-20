using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;

namespace MyRecipeBook.Application.UseCases.User.Login.WithEmailAndPassword;

public interface ILoginWithEmailAndPassword
{
    Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request);
}
