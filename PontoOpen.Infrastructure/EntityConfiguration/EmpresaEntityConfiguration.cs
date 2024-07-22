using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Infrastructure.EntityConfiguration;

public class EmpresaEntityConfiguration : BaseEntityConfiguration<Empresa>
{
    public override void Configure(EntityTypeBuilder<Empresa> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.RazaoSocial)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.NomeFantasia)
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(x => x.Cnpj)
            .IsRequired()
            .HasMaxLength(14);

        builder.HasOne(x => x.AcessoEmpresa)
            .WithOne(x => x.Empresa)
            .HasForeignKey<AcessoEmpresa>(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(x => x.Usuarios)
            .WithOne(x => x.Empresa)
            .HasForeignKey(x => x.EmpresaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
