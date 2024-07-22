using Microsoft.EntityFrameworkCore;
using PontoOpen.Domain.Entities;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Context;

namespace PontoOpen.Infrastructure.Repositories;

public sealed class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _appDbContext;

    public EmpresaRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Empresa?> GetByChaveDeAcessoAsync(long chaveDeAcesso)
    {
        return await _appDbContext
            .Empresas
            .AsNoTracking()
            .Include(x => x.AcessoEmpresa)
            .FirstOrDefaultAsync(x => x.AcessoEmpresa.ChaveDeAcesso == chaveDeAcesso);
    }
}
