using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface IEmpresaRepository
{
    Task<Empresa?> GetByChaveDeAcessoAsync(long chaveDeAcesso);
}
