using Microsoft.AspNetCore.Mvc;
using PontoOpen.Api.Attributes;
using PontoOpen.Application.Dtos.Pontos;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Api.Controllers;

[ApiController]
[Route("ponto")]
[AutenticationUsuario]
public class PontoController : ControllerApiBase<PontoViewModel>
{
    private readonly IPontoService _pontoService;

    public PontoController(IPontoService pontoService)
    {
        _pontoService = pontoService;
    }

    [HttpPost]
    [ProducesResponseType<PontoViewModel>(201)]
    [ProducesResponseType<ErrorResponse>(401)]
    [ProducesResponseType<ErrorResponse>(400)]
    public async Task<IActionResult> Create(PontoDto pontoDto)
    {
        var result = await _pontoService.CreateAsync(pontoDto);

        return ResultResponse(result, created: true, $"ponto?id={result.AsT0?.Id}");
    }

    [HttpGet("ultimos-pontos")]
    [ProducesResponseType<PontoViewModel>(200)]
    [ProducesResponseType<ErrorResponse>(401)]
    [ProducesResponseType<ErrorResponse>(400)]
    public async Task<IActionResult> UltimosPontos()
    {
        var result = await _pontoService.GetUltimosPontosAsync();

        return ResultList(result);
    }
}
