using OneOf;
using PontoOpen.Application.Dtos.GoogleApi;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Application.Interfaces;

public interface IGoogleApiService
{
    Task<OneOf<GoogleApiReponseViewModel, ErrorResponse>> GetEnderecoByLatLogAsync(LocalizacaoLatLogDto localizacaoLatLogDto);
}
