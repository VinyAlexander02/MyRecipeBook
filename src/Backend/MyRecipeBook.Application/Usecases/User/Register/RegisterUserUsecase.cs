using AutoMapper;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Response;
using MyRecipeBook.Domain.Entities;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exeptions.ExceptionsBase;

namespace MyRecipeBook.Application.Usecases.User.Register;

public class RegisterUserUsecase : IRegisterUserUsecase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;
    private readonly IMapper _mapper;
    private PasswordEncripter _passwordEncripter;

    public RegisterUserUsecase(IUserWriteOnlyRepository writeOnlyRepository, IUserReadOnlyRepository readOnlyRepository, PasswordEncripter passwordEncripter, IMapper mapper)
    {
        _writeOnlyRepository = writeOnlyRepository;
        _readOnlyRepository = readOnlyRepository;
        _passwordEncripter = passwordEncripter;
        _mapper = mapper;
    }

    public async Task <ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
    {
        // Validar a Request 
        Validate(request);

        var user = _mapper.Map<Domain.Entities.User>(request);

        // Criptografar a senha 
        user.Password = _passwordEncripter.Encrypt(request.Password);

        // Salvar no bando de dados 
        await _writeOnlyRepository.Add(user);
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
