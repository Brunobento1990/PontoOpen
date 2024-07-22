using Microsoft.AspNetCore.Mvc;
using PontoOpen.Application.Dtos.Logins;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Api.Controllers;

[ApiController]
[Route("login")]
public class LoginController : ControllerApiBase<UsuarioViewModel>
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("usuario")]
    [ProducesResponseType<UsuarioViewModel>(200)]
    [ProducesResponseType<ErrorResponse>(401)]
    [ProducesResponseType<ErrorResponse>(400)]
    public async Task<IActionResult> Login(UsuarioLoginDto usuarioLoginDto)
    {
        var result = await _loginService.LoginAsync(usuarioLoginDto);

        return ResultResponse(result);
    }
}
