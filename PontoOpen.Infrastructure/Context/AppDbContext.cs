using Microsoft.EntityFrameworkCore;
using PontoOpen.Domain.Entities;
using System.Reflection;

namespace PontoOpen.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Empresa> Empresas { get; set; }
    public DbSet<AcessoUsuario> AcessosUsuarios { get; set; }
    public DbSet<AcessoEmpresa> AcessosEmpresas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
