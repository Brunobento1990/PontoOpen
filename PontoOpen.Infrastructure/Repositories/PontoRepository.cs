using Microsoft.EntityFrameworkCore;
using PontoOpen.Domain.Entities;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Context;

namespace PontoOpen.Infrastructure.Repositories;

public sealed class PontoRepository : IPontoRepository
{
    private readonly AppDbContext _appDbContext;

    public PontoRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task AddAsync(Ponto ponto)
    {
        await _appDbContext.AddAsync(ponto);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<IList<Ponto>> GetUltimosPontosAsync(Guid usuarioId)
    {
        var ultimoPonto = await _appDbContext
            .Pontos
            .AsNoTracking()
            .Where(x => x.UsuarioId == usuarioId)
            .MaxAsync(x => x.CreatedAt);

        return await _appDbContext
            .Pontos
            .AsNoTracking()
            .OrderBy(x => x.Horario)
            .Where(x => x.CreatedAt.Date == ultimoPonto.Date && x.UsuarioId == usuarioId)
            .ToListAsync();
    }
}
