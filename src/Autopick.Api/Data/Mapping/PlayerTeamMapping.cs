using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class PlayerTeamMapping : IEntityTypeConfiguration<PlayerTeam>
    {
        public void Configure(EntityTypeBuilder<PlayerTeam> builder)
        {
            builder.ToTable("PlayerTeam");
            builder.HasOne(b => b.Player)
                   .WithMany(ba => ba.PlayerTeam)
                   .HasForeignKey(bi => bi.PlayerId);

            builder.HasOne(b => b.Team)
                   .WithMany(ba => ba.PlayerTeam)
                   .HasForeignKey(bi => bi.TeamId);
        }
    }
}
