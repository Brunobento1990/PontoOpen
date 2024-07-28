using Microsoft.AspNetCore.Http.Features;
using PontoOpen.Api.Attributes;
using PontoOpen.Domain.Exceptions;
using PontoOpen.Domain.Interfaces;

namespace PontoOpen.Api.Middlewares;

public class AutenticationUsuarioMiddleware
{
    private readonly RequestDelegate _next;
    public AutenticationUsuarioMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(
        HttpContext httpContext,
        IUsuarioAutenticado usuarioAutenticado,
        IUsuarioRepository usuarioRepository,
        IEmpresaRepository empresaRepository)
    {
        var autenticar = httpContext.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata
                .FirstOrDefault(m => m is AutenticationUsuarioAttribute) is AutenticationUsuarioAttribute;

        if (!autenticar)
        {
            await _next(httpContext);
            return;
        }

        var chaveDeAcessoEmpresa = (string?)httpContext
            .Request
            .Headers
            .FirstOrDefault(x => x.Key.ToLower() == "chavedeacessoempresa")
            .Value;

        var chaveDeAcessoUsuario = (string?)httpContext
            .Request
            .Headers
            .FirstOrDefault(x => x.Key.ToLower() == "chavedeacessousuario")
            .Value;

        if (string.IsNullOrWhiteSpace(chaveDeAcessoEmpresa) || string.IsNullOrWhiteSpace(chaveDeAcessoUsuario) ||
            !long.TryParse(chaveDeAcessoUsuario, out long _chaveDeAcessoUsuario) || !long.TryParse(chaveDeAcessoEmpresa, out long _chaveDeAcessoEmpresa))
        {
            throw new UnauthorizedException("Credenciais de acesso inválidas!");
        }

        var usuario = await usuarioRepository.GetByChaveDeAcessoAsync(_chaveDeAcessoUsuario)
            ?? throw new UnauthorizedException("O usuário não foi localizado");
        var empresa = await empresaRepository.GetByChaveDeAcessoAsync(_chaveDeAcessoEmpresa)
            ?? throw new UnauthorizedException("A empresa não foi localizada!");

        if (usuario.AcessoUsuario.Inativo || usuario.AcessoUsuario.Bloqueado)
        {
            throw new UnauthorizedException("Seu acesso está bloqueado!");
        }

        if (empresa.AcessoEmpresa.Bloqueada)
        {
            throw new UnauthorizedException("Sua empresa está bloqueada, entre em contato com um responsável!");
        }

        usuarioAutenticado.UsuarioId = usuario.Id;
        usuarioAutenticado.EmpresaId = empresa.Id;
        usuarioAutenticado.SetUsuario(usuario);
        usuarioAutenticado.SetEmpresa(empresa);

        await _next(httpContext);
    }
}
