using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class ModalityMapping : IEntityTypeConfiguration<Modality>
    {
        public void Configure(EntityTypeBuilder<Modality> builder)
        {
            builder.ToTable("Modality")
                   .HasKey(m => m.Id);

            builder.Property(a => a.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasColumnType("VARCHAR(50)");

            builder.Property(a => a.Description)
                   .HasColumnName("Description")
                   .HasColumnType("VARCHAR(240)");

            builder.HasMany(m => m.Skills)
                   .WithOne(s => s.Modality)
                   .HasForeignKey(s => s.ModalityId);

            builder.HasMany(m => m.Matches)
                   .WithOne(m => m.Modality)
                   .HasForeignKey(s => s.ModalityId);

            builder.HasMany(m => m.PlayerOveralls)
                   .WithOne(m => m.Modality)
                   .HasForeignKey(s => s.ModalityId);

            builder.HasMany(m => m.Teams)
                   .WithOne(m => m.Modality)
                   .HasForeignKey(s => s.ModalityId);

        }
    }
}
