using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exeptions.ExceptionsBase;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserUsecase
{
    private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
    private readonly IUserReadOnlyRepository _userRepository;
    public async Task <ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        // Validar a Request 
        Validate(request);

        // Mapear a entidade para receber os dados
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        var user = autoMapper.Map<Domain.Entities.User>(request);

        // Criptografar a senha 
        var cripPassword = new PasswordEncripter();
        user.Password = cripPassword.Encrypt(request.Password);

        // Salvar no bando de dados 
        _userWriteOnlyRepository.Add(user);
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
