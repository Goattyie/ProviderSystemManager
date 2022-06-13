using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class AbonentConfiguration : IEntityTypeConfiguration<Abonent>
{
    public void Configure(EntityTypeBuilder<Abonent> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.HasIndex(x => x.Address).IsUnique();
        builder.Property(x => x.Address).IsRequired();
        builder.HasMany(x => x.Services)
            .WithOne(a => a.Abonent);
        builder.HasOne(x => x.AbonentType)
            .WithMany(a => a.Abonents)
            .HasForeignKey(k => k.AbonentTypeId);
    }
}