namespace PontoOpen.Domain.Exceptions;

public class ApiException(string message) : Exception(message)
{
}
