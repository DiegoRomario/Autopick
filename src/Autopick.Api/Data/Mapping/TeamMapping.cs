using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class TeamMapping : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Team")
                 .HasKey(m => m.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(p => p.ModalityId)
                   .IsRequired();

            builder.Property(p => p.Overall)
                   .IsRequired();

            builder.HasMany(p => p.Players)
                   .WithMany(p => p.Teams)
                   .UsingEntity<PlayerTeam>();

            builder.HasMany(p => p.Matches)
                   .WithMany(p => p.Teams)
                   .UsingEntity<Dictionary<string, object>>("TeamMatch", j => j
                   .HasOne<Match>()
                   .WithMany()
                   .HasForeignKey("MatchId"),
                   j => j
                   .HasOne<Team>()
                   .WithMany()
                   .HasForeignKey("TeamId"));
        }
    }
}
