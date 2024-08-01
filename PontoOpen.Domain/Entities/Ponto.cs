
namespace PontoOpen.Domain.Entities;

public sealed class Ponto : BaseEntity
{
    public Ponto(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        TimeSpan horario,
        Guid usuarioId,
        string endereco)
            : base(id, createdAt, updatedAt)
    {
        Horario = horario;
        UsuarioId = usuarioId;
        Endereco = endereco;
    }

    public TimeSpan Horario { get; private set; }
    public Guid UsuarioId { get; private set; }
    public string Endereco { get; private set; }
    public Usuario Usuario { get; set; } = null!;
}
