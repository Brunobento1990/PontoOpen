using PontoOpen.Domain.Entities;

namespace PontoOpen.Application.ViewModels;

public class PontoViewModel : BaseViewModel
{
    public TimeSpan Horario { get; set; }
    public Guid UsuarioId { get; set; }
    public UsuarioViewModel Usuario { get; set; } = null!;

    public static explicit operator PontoViewModel(Ponto ponto)
    {
        return new PontoViewModel()
        {
            CreatedAt = ponto.CreatedAt,
            Horario = ponto.Horario,
            Id = ponto.Id,
            UpdatedAt = ponto.UpdatedAt,
            Usuario = ponto.Usuario != null ? (UsuarioViewModel)ponto.Usuario : null!,
            UsuarioId = ponto.UsuarioId
        };
    }
}
