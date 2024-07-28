using PontoOpen.Domain.Entities;
using PontoOpen.Domain.Exceptions;
using PontoOpen.Domain.Interfaces;

namespace PontoOpen.Infrastructure.Models;

public sealed class UsuarioAutenticado : IUsuarioAutenticado
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IEmpresaRepository _empresaRepository;

    public UsuarioAutenticado(
        IUsuarioRepository usuarioRepository,
        IEmpresaRepository empresaRepository)
    {
        _usuarioRepository = usuarioRepository;
        _empresaRepository = empresaRepository;
    }

    public Guid UsuarioId { get; set; }
    public Guid EmpresaId { get; set; }
    private Empresa Empresa { get; set; } = null!;
    private Usuario Usuario { get; set; } = null!;

    public void SetUsuario(Usuario usuario)
    {
        if (usuario == null) return;
        Usuario = usuario;
    }

    public void SetEmpresa(Empresa empresa) 
    {
        if (empresa == null) return;
        Empresa = empresa;
    }

    public async Task<Empresa> GetEmpresaAutenticadaAsync()
    {
        Empresa ??= await _empresaRepository.GetByIdAsync(EmpresaId)
            ?? throw new ApiException("A empresa não foi localizada!");

        return Empresa;
    }

    public async Task<Usuario> GetUsuarioAutenticadoAsync()
    {
        Usuario ??= await _usuarioRepository.GetByIdAsync(UsuarioId)
            ?? throw new ApiException("O usuário não foi localizado!");

        return Usuario;
    }
}
