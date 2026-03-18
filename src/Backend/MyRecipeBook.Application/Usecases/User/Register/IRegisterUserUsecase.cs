using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;

namespace MyRecipeBook.Application.Usecases.User.Register;

public interface IRegisterUserUsecase
{
    public Task <ResponseRegisterUserJson> Execute(RequestRegisterUserJson request);
}
