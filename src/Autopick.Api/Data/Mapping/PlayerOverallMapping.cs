using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class PlayerOverallMapping : IEntityTypeConfiguration<PlayerOverall>
    {
        public void Configure(EntityTypeBuilder<PlayerOverall> builder)
        {
            builder.ToTable("PlayerOverall")
                    .HasKey(p => p.Id);

            builder.Property(p => p.PlayerId)
                   .IsRequired();

            builder.Property(p => p.ModalityId)
                   .IsRequired();

            builder.HasMany(p => p.PlayerSkillRatings)
                   .WithOne(p => p.PlayerOverall)
                   .HasForeignKey(p => p.PlayerOverallId);

            builder.Property(p => p.Overall)
                   .IsRequired();
        }
    }
}
