using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface IUsuarioAutenticado
{
    Guid UsuarioId { get; set; }
    Guid EmpresaId { get; set; }
    Task<Empresa> GetEmpresaAutenticadaAsync();
    Task<Usuario> GetUsuarioAutenticadoAsync();
    void SetUsuario(Usuario usuario);
    void SetEmpresa(Empresa empresa);
}
