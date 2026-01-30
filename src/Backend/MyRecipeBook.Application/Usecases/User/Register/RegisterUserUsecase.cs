using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Exeptions.ExceptionsBase;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserUsecase
{
    public ResponseRegisterUserJson Execute(RequestRegisterUserJson request)
    {
        // Validar a Request 
        Validate(request);

        // Mapear a entidade para receber os dados
        var user = new Domain.Entities.User
        {
            Name = request.Name,
            Email = request.Email,
            Password = request.Password,
        };

        // Criptografar a senha 

        // Salvar no bando de dados 
        return new ResponseRegisterUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorsMessage = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorsMessage);
        }
    }
}
