using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface ILoginRepository
{
    Task<Usuario?> LoginAsync(long chaveDeAcesso);
}
