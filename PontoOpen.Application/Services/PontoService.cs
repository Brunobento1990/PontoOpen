using OneOf;
using PontoOpen.Application.Dtos.Pontos;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;
using PontoOpen.Domain.Interfaces;

namespace PontoOpen.Application.Services;

public sealed class PontoService : IPontoService
{
    private readonly IPontoRepository _pontoRepository;
    private readonly IUsuarioAutenticado _usuarioAutenticado;

    public PontoService(
        IPontoRepository pontoRepository,
        IUsuarioAutenticado usuarioAutenticado)
    {
        _pontoRepository = pontoRepository;
        _usuarioAutenticado = usuarioAutenticado;
    }

    public async Task<OneOf<PontoViewModel, ErrorResponse>> CreateAsync(PontoDto pontoDto)
    {
        var ponto = pontoDto.ToEntity(_usuarioAutenticado.UsuarioId);
        await _pontoRepository.AddAsync(ponto);

        return (PontoViewModel)ponto;
    }

    public async Task<IList<PontoViewModel>> GetUltimosPontosAsync()
    {
        var ultimosPontos = await _pontoRepository.GetUltimosPontosAsync(_usuarioAutenticado.UsuarioId);

        return ultimosPontos.Select(x => (PontoViewModel)x).ToList();
    }
}
