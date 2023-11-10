using StageRaceFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace StageRaceFantasy.Infrastructure.Persistence.EntityConfigurations;

public class StageRaceFantasyEntityTypeConfiguration : IEntityTypeConfiguration<StageRaceEntity>
{
    public void Configure(EntityTypeBuilder<StageRaceEntity> builder)
    {
        builder.ToTable("StageRace");

        builder.Property(_ => _.Id)
            .HasColumnName("StageRaceId");

        builder.Property(_ => _.Name)
            .HasColumnType("nvarchar(256)");
    }
}
