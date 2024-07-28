
namespace PontoOpen.Domain.Entities;

public sealed class Ponto : BaseEntity
{
    public Ponto(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        TimeSpan horario,
        Guid usuarioId)
            : base(id, createdAt, updatedAt)
    {
        Horario = horario;
        UsuarioId = usuarioId;
    }

    public TimeSpan Horario { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
}
