using OneOf;
using PontoOpen.Application.Dtos.GoogleApi;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;
using PontoOpen.Infrastructure.HttpService.Interfaces;

namespace PontoOpen.Application.Services;

public sealed class GoogleApiService : IGoogleApiService
{
    private readonly IGoogleHttpService _googleHttpService;

    public GoogleApiService(IGoogleHttpService googleHttpService)
    {
        _googleHttpService = googleHttpService;
    }

    public async Task<OneOf<GoogleApiReponseViewModel, ErrorResponse>> GetEnderecoByLatLogAsync(
        LocalizacaoLatLogDto localizacaoLatLogDto)
    {
        if (!localizacaoLatLogDto.Validar())
        {
            return new ErrorResponse("Latitude e longitude inválidas!");
        }

        var response = await _googleHttpService
            .GetAddressByLocationAsync(localizacaoLatLogDto.Latitude, localizacaoLatLogDto.Longitude);

        if (response == null || response.Results.Count == 0) 
        {
            return new ErrorResponse("Não foi possível acessar sua localização!");
        }

        var result = response.Results.ElementAtOrDefault(0);

        return new GoogleApiReponseViewModel()
        {
            Endereco = result?.Formatted_address ?? "Sem endereço!",
        };
    }
}
