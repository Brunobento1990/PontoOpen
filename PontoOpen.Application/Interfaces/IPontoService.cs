using OneOf;
using PontoOpen.Application.Dtos.Pontos;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Application.Interfaces;

public interface IPontoService
{
    Task<OneOf<PontoViewModel, ErrorResponse>> CreateAsync(PontoDto pontoDto);
    Task<IList<PontoViewModel>> GetUltimosPontosAsync();
}
