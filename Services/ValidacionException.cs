namespace Casos1.Services;

public class ValidacionException : Exception
{
    public ValidacionException(string message)
        : base(message)
    {
    }
}