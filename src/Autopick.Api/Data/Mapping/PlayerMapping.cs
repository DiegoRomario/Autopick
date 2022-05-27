
using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class PlayerMapping : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder.ToTable("Player")
                   .HasKey(p => p.Id);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR(60)");

            builder.Property(p => p.BirthDate)
                   .HasColumnName("BirthDate")
                   .IsRequired();

            builder.Property(p => p.Foot)
                   .HasColumnName("Foot")
                   .HasColumnType("TINYINT")
                   .IsRequired();

            builder.Property(p => p.Weight)
                   .HasColumnName("Weight")
                   .IsRequired();

            builder.Property(p => p.Height)
                   .HasColumnName("Height")
                   .IsRequired();

            builder.HasMany(p => p.PlayerOveralls)
                   .WithOne(p => p.Player)
                   .HasForeignKey(p => p.PlayerId);

            builder.HasMany(p => p.Groups)
                   .WithMany(p => p.Players)
                   .UsingEntity<Dictionary<string, object>>("PlayerGroup", j => j
                   .HasOne<Group>()
                   .WithMany()
                   .HasForeignKey("GroupId"), j => j
                   .HasOne<Player>()
                   .WithMany()
                   .HasForeignKey("PlayerId"));

            builder.HasMany(p => p.Teams)
                    .WithMany(p => p.Players)
                    .UsingEntity<PlayerTeam>();
        }
    }
}
