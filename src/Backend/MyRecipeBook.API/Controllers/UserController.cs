using Microsoft.AspNetCore.Mvc;
using MyRecipeBook.Application.Usecases.User.Register;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;

namespace MyRecipeBook.API.Controllers;
[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUsecase();
        var result = useCase.Execute(request);
        return Created(string.Empty, result);
    }
}

