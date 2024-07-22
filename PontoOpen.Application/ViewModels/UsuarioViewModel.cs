using PontoOpen.Domain.Entities;

namespace PontoOpen.Application.ViewModels;

public class UsuarioViewModel : BaseViewModel
{
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public EmpresaViewModel Empresa { get; set; } = null!;

    public static explicit operator UsuarioViewModel(Usuario usuario)
    {
        return new()
        {
            Cpf = usuario.Cpf,
            Email = usuario.Email,
            Nome = usuario.Nome,
            CreatedAt = usuario.CreatedAt,
            Id = usuario.Id,
            UpdatedAt = usuario.UpdatedAt,
            Empresa = usuario.Empresa != null ? (EmpresaViewModel)usuario.Empresa : null!
        };
    }
}
