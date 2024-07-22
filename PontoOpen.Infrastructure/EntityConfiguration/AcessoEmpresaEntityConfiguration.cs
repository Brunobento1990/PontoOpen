using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Infrastructure.EntityConfiguration;

public class AcessoEmpresaEntityConfiguration : BaseEntityConfiguration<AcessoEmpresa>
{
    public override void Configure(EntityTypeBuilder<AcessoEmpresa> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ChaveDeAcesso)
            .IsRequired();
        builder.Property(x => x.Bloqueada)
            .IsRequired();

        builder.HasIndex(x => x.ChaveDeAcesso)
            .IsUnique();
    }
}
