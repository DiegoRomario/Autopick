using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class SkillMapping : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skill")
                   .HasKey(m => m.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(a => a.Description)
                   .HasColumnName("Description")
                   .HasColumnType("VARCHAR(240)");

            builder.Property(p => p.ModalityId)
                   .IsRequired();

            builder.HasMany(s => s.PlayerRatings)
                   .WithOne(p => p.Skill)
                   .HasForeignKey(p => p.SkillId);
        }
    }
}
