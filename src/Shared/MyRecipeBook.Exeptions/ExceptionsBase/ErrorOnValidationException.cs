

namespace MyRecipeBook.Exeptions.ExceptionsBase;
public class ErrorOnValidationException : MyRecipeBookException
{
    public IList<string> ErrorsMessage { get; set; }

    public ErrorOnValidationException(IList<string> errorsMessage)
    {
        ErrorsMessage = errorsMessage;

    }
}

