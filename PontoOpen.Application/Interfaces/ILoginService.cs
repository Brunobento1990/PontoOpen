using OneOf;
using PontoOpen.Application.Dtos.Logins;
using PontoOpen.Application.ViewModels;

namespace PontoOpen.Application.Interfaces;

public interface ILoginService
{
    Task<OneOf<UsuarioViewModel, ErrorResponse>> LoginAsync(UsuarioLoginDto usuarioLoginDto);
}
