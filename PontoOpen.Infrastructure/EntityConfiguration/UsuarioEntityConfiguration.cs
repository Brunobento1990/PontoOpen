using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Infrastructure.EntityConfiguration;

public class UsuarioEntityConfiguration : BaseEntityConfiguration<Usuario>
{
    public override void Configure(EntityTypeBuilder<Usuario> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.Nome)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Cpf)
            .IsRequired()
            .HasMaxLength(11);

        builder.HasIndex(x => x.Cpf)
            .IsUnique();
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.HasIndex(x => x.Nome);

        builder.HasOne(x => x.AcessoUsuario)
            .WithOne(x => x.Usuario)
            .HasForeignKey<AcessoUsuario>(x => x.UsuarioId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
