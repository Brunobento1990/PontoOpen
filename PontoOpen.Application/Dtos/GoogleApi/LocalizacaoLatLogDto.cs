namespace PontoOpen.Application.Dtos.GoogleApi;

public class LocalizacaoLatLogDto
{
    public string Latitude { get; set; } = string.Empty;
    public string Longitude { get; set; } = string.Empty;

    public bool Validar()
    {
        return !string.IsNullOrWhiteSpace(Latitude) || !string.IsNullOrWhiteSpace(Longitude);
    }
}
