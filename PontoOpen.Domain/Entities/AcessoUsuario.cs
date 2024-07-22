
namespace PontoOpen.Domain.Entities;

public sealed class AcessoUsuario : BaseEntity
{
    public AcessoUsuario(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        long chaveDeAcesso,
        bool bloqueado,
        Guid usuarioId,
        bool inativo)
            : base(id, createdAt, updatedAt)
    {
        ChaveDeAcesso = chaveDeAcesso;
        Bloqueado = bloqueado;
        UsuarioId = usuarioId;
        Inativo = inativo;
    }

    public long ChaveDeAcesso { get; private set; }
    public bool Bloqueado { get; private set; }
    public bool Inativo { get; private set; }
    public Guid UsuarioId { get; private set; }
    public Usuario Usuario { get; set; } = null!;
}
