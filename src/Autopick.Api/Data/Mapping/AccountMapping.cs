using Autopick.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autopick.Api.Data.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account")
                   .HasKey(a => a.Id);
            builder.Property(a => a.Email)
                   .IsRequired()
                   .HasColumnName("Email")
                   .HasColumnType("VARCHAR(50)");

            builder.HasMany(a => a.Groups)
                   .WithOne(g => g.Account)
                   .HasForeignKey(g => g.AccountId);

        }
    }

}
