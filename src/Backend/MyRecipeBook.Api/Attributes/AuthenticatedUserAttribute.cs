using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Api.Filters;

namespace MyRecipeBook.Api.Attributes;

public class AuthenticatedUserAttribute : TypeFilterAttribute
{
    public AuthenticatedUserAttribute() : base(typeof(AuthenticatedUserFilter))
    {
    }
}
