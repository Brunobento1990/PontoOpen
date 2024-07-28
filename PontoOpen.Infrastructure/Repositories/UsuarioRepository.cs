using Microsoft.EntityFrameworkCore;
using PontoOpen.Domain.Entities;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Context;

namespace PontoOpen.Infrastructure.Repositories;

public sealed class UsuarioRepository : IUsuarioRepository
{
    private readonly AppDbContext _appDbContext;

    public UsuarioRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Usuario?> GetByChaveDeAcessoAsync(long chaveDeAcesso)
    {
        return await _appDbContext
            .Usuarios
            .AsNoTracking()
            .Include(x => x.AcessoUsuario)
            .FirstOrDefaultAsync(x => x.AcessoUsuario.ChaveDeAcesso == chaveDeAcesso);
    }

    public async Task<Usuario?> GetByIdAsync(Guid id)
    {
        return await _appDbContext
            .Usuarios
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
