using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(Guid id);
    Task<Usuario?> GetByChaveDeAcessoAsync(long chaveDeAcesso);
}
