using Microsoft.EntityFrameworkCore;
using PontoOpen.Domain.Entities;
using PontoOpen.Domain.Interfaces;
using PontoOpen.Infrastructure.Context;

namespace PontoOpen.Infrastructure.Repositories;

public sealed class LoginRepository : ILoginRepository
{
    private readonly AppDbContext _appDbContext;

    public LoginRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Usuario?> LoginAsync(long chaveDeAcesso)
    {
        return await _appDbContext
            .Usuarios
            .AsNoTracking()
            .Include(x => x.AcessoUsuario)
            .FirstOrDefaultAsync(x => x.AcessoUsuario.ChaveDeAcesso == chaveDeAcesso);
    }
}
