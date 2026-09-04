using Bogus;
using MyRecipeBook.Communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegisterUserAccountJsonBuilder
{
    public static RequestRegisterUserAccountJson Build()
    {
        return new Faker<RequestRegisterUserAccountJson>()
            .RuleFor(r => r.Name, f => f.Person.FirstName)
            .RuleFor(r => r.Email, (f, request) => f.Internet.Email(request.Name))
            .RuleFor(r => r.Password, f => f.Internet.Password());
    }
}
