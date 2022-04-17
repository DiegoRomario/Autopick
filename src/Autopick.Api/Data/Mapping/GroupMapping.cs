using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class GroupMapping : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group")
                   .HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(a => a.AccountId).IsRequired();

            builder.HasMany(g => g.Matches)
                   .WithOne(m => m.Group)
                   .HasForeignKey(m => m.GroupId);

            builder.HasMany(p => p.Players)
                   .WithMany(p => p.Groups)
                   .UsingEntity<Dictionary<string, object>>("PlayerGroup", j => j
                   .HasOne<Player>()
                   .WithMany()
                   .HasForeignKey("PlayerId"),
                   j => j
                   .HasOne<Group>()
                   .WithMany()
                   .HasForeignKey("GroupId"));

        }
    }
}
