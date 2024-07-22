using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Infrastructure.EntityConfiguration;

public class AcessoUsuarioEntityConfiguration : BaseEntityConfiguration<AcessoUsuario>
{
    public override void Configure(EntityTypeBuilder<AcessoUsuario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.ChaveDeAcesso)
            .IsRequired();
        builder.Property(x => x.Bloqueado)
            .IsRequired();
        builder.Property(x => x.Inativo)
                    .IsRequired();
        builder.HasIndex(x => x.ChaveDeAcesso)
            .IsUnique();
    }
}
