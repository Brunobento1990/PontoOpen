using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontoOpen.Domain.Entities;

namespace PontoOpen.Infrastructure.EntityConfiguration;

public class PontoEntityConfiguration : BaseEntityConfiguration<Ponto>
{
    public override void Configure(EntityTypeBuilder<Ponto> builder)
    {
        base.Configure(builder);

        builder.HasIndex(x => x.CreatedAt);
        builder.Property(x => x.Horario)
            .IsRequired();
    }
}
