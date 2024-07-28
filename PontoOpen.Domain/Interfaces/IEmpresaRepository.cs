using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface IEmpresaRepository
{
    Task<Empresa?> GetByChaveDeAcessoAsync(long chaveDeAcesso);
    Task<Empresa?> GetByIdAsync(Guid id);
}
