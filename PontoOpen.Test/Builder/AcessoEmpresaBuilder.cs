using PontoOpen.Domain.Entities;

namespace PontoOpen.Test.Builder;

public class AcessoEmpresaBuilder
{
    private readonly Guid _id;
    private Guid _empresaId;
    private readonly DateTime _createdAt;
    private readonly DateTime _updateAt;
    private long _chaveDeAcesso;
    private bool _bloqueada;
    public AcessoEmpresaBuilder()
    {
        _id = Guid.NewGuid();
        _empresaId = Guid.NewGuid();
        _createdAt = DateTime.Now;
        _updateAt = DateTime.Now;
    }

    public static AcessoEmpresaBuilder Init() => new();

    public AcessoEmpresaBuilder AddChaveDeAcesso(long chaveDeAcesso)
    {
        _chaveDeAcesso = chaveDeAcesso;
        return this;
    }

    public AcessoEmpresaBuilder AddBloqueada(bool bloqueada)
    {
        _bloqueada = bloqueada;
        return this;
    }

    public AcessoEmpresaBuilder AddEmpresaId(Guid empresaId)
    {
        _empresaId = empresaId;
        return this;
    }

    public AcessoEmpresa Build()
    {
        return new AcessoEmpresa(
            id: _id,
            createdAt: _createdAt,
            updatedAt: _updateAt,
            chaveDeAcesso: _chaveDeAcesso,
            empresaId: _empresaId,
            bloqueada: _bloqueada);
    }
}
