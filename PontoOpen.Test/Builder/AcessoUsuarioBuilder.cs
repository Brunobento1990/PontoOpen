using PontoOpen.Domain.Entities;

namespace PontoOpen.Test.Builder;

public class AcessoUsuarioBuilder
{
    private readonly Guid _id;
    private readonly DateTime _createdAt;
    private readonly DateTime _updateAt;
    private long _chaveDeAcesso;
    private bool _bloqueado;
    private bool _inativo;
    private Guid _usuarioId;
    public AcessoUsuarioBuilder()
    {
        
    }

    public AcessoUsuarioBuilder AddUsuarioId(Guid usuarioId)
    {
        _usuarioId = usuarioId;
        return this;
    }

    public AcessoUsuarioBuilder AddInativo(bool inativo)
    {
        _inativo = inativo;
        return this;
    }

    public AcessoUsuarioBuilder AddBloquado(bool bloqueado)
    {
        _bloqueado = bloqueado;
        return this;
    }

    public AcessoUsuarioBuilder AddChaveDeAcesso(long chaveDeAcesso)
    {
        _chaveDeAcesso = chaveDeAcesso;
        return this;
    }

    public static AcessoUsuarioBuilder Init() => new();

    public AcessoUsuario Build()
    {
        return new AcessoUsuario(
            id: _id,
            createdAt: _createdAt,
            updatedAt: _updateAt,
            chaveDeAcesso: _chaveDeAcesso,
            bloqueado: _bloqueado,
            usuarioId: _usuarioId,
            inativo: _inativo);
    }
}
