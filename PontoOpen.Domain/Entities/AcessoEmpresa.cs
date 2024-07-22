
namespace PontoOpen.Domain.Entities;

public sealed class AcessoEmpresa : BaseEntity
{
    public AcessoEmpresa(
        Guid id,
        DateTime createdAt,
        DateTime? updatedAt,
        long chaveDeAcesso,
        Guid empresaId,
        bool bloqueada)
            : base(id, createdAt, updatedAt)
    {
        ChaveDeAcesso = chaveDeAcesso;
        EmpresaId = empresaId;
        Bloqueada = bloqueada;
    }

    public long ChaveDeAcesso { get; private set; }
    public bool Bloqueada { get; private set; }
    public Guid EmpresaId { get; private set; }
    public Empresa Empresa { get; set; } = null!;
}
