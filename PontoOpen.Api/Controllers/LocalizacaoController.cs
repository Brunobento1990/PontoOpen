using Microsoft.AspNetCore.Mvc;
using PontoOpen.Api.Attributes;
using PontoOpen.Application.Dtos.GoogleApi;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Api.Controllers;

[ApiController]
[Route("localizacao")]
[AutenticationUsuario]
public class LocalizacaoController : ControllerApiBase<GoogleApiReponseViewModel>
{
    private readonly IGoogleApiService _googleApiService;

    public LocalizacaoController(IGoogleApiService googleApiService)
    {
        _googleApiService = googleApiService;
    }

    [HttpPost]
    [ProducesResponseType<GoogleApiReponseViewModel>(201)]
    [ProducesResponseType<ErrorResponse>(401)]
    [ProducesResponseType<ErrorResponse>(400)]
    public async Task<IActionResult> GetLocalizacao(LocalizacaoLatLogDto localizacaoLatLogDto)
    {
        var result = await _googleApiService.GetEnderecoByLatLogAsync(localizacaoLatLogDto);
        return ResultResponse(result);
    }
}
