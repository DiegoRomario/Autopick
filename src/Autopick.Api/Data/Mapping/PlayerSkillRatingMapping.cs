using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class PlayerSkillRatingMapping : IEntityTypeConfiguration<PlayerSkillRating>
    {
        public void Configure(EntityTypeBuilder<PlayerSkillRating> builder)
        {
            builder.ToTable("PlayerSkillRating")
                   .HasKey(p => p.Id);

            builder.Property(p => p.PlayerOverallId)
                   .IsRequired();

            builder.Property(p => p.SkillId)
                   .IsRequired();

            builder.Property(p => p.Rating)
                   .IsRequired();
        }
    }
}
