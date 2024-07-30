namespace PontoOpen.Infrastructure.Models;

public class ResponseApiLocalizacaoGoogle
{
    public string Status { get; set; } = string.Empty;
    public IList<Result> Results { get; set; } = [];
}

public class Result
{
    public string Formatted_address { get; set; } = string.Empty;
    public string Place_id { get; set; } = string.Empty;
}
