using OneOf;
using PontoOpen.Application.Dtos.Logins;
using PontoOpen.Application.Interfaces;
using PontoOpen.Application.ViewModels;
using PontoOpen.Domain.Interfaces;

namespace PontoOpen.Application.Services;

public sealed class LoginService : ILoginService
{
    private readonly IEmpresaRepository _empresaRepository;
    private readonly ILoginRepository _loginRepository;

    public LoginService(
        IEmpresaRepository empresaRepository,
        ILoginRepository loginRepository)
    {
        _empresaRepository = empresaRepository;
        _loginRepository = loginRepository;
    }

    public async Task<OneOf<UsuarioViewModel, ErrorResponse>> LoginAsync(UsuarioLoginDto usuarioLoginDto)
    {
        if (!usuarioLoginDto.Validar())
        {
            return new ErrorResponse("Os dados enviados para o login são inválidos!");
        }

        var usuario = await _loginRepository.LoginAsync(usuarioLoginDto.ChaveDeAcessoUsuario);

        if (usuario == null)
        {
            return new ErrorResponse("O usuário não foi localizado!");
        }

        if (usuario.AcessoUsuario.Bloqueado)
        {
            return new ErrorResponse("Usuário bloqueado!");
        }

        if (usuario.AcessoUsuario.Inativo)
        {
            return new ErrorResponse("Usuário inativo!");
        }

        var empresa = await _empresaRepository.GetByChaveDeAcessoAsync(usuarioLoginDto.ChaveDeAcessoEmpresa);

        if (empresa == null)
        {
            return new ErrorResponse("A empresa não foi localizada!");
        }

        if (empresa.AcessoEmpresa.Bloqueada)
        {
            return new ErrorResponse("A empresa está bloquada!");
        }

        usuario.Empresa = empresa;

        return (UsuarioViewModel)usuario;
    }
}
