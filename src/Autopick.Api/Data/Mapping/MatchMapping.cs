using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class MatchMapping : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder.ToTable("Match")
                   .HasKey(m => m.Id);

            builder.Property(a => a.Date)
                    .IsRequired()
                    .HasColumnName("Date");

            builder.Property(m => m.ModalityId).IsRequired();
            builder.Property(m => m.GroupId).IsRequired();

            builder.HasMany(p => p.Teams)
                   .WithMany(p => p.Matches)
                   .UsingEntity<Dictionary<string, object>>("TeamMatch", j => j
                   .HasOne<Team>()
                   .WithMany()
                   .HasForeignKey("TeamId"),
                   j => j
                   .HasOne<Match>()
                   .WithMany()
                   .HasForeignKey("MatchId"));

        }
    }
}
