using PontoOpen.Domain.Entities;

namespace PontoOpen.Domain.Interfaces;

public interface IPontoRepository
{
    Task AddAsync(Ponto ponto);
    Task<IList<Ponto>> GetUltimosPontosAsync(Guid usuarioId);
}
