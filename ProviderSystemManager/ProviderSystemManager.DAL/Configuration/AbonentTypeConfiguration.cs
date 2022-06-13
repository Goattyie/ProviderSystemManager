using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class AbonentTypeConfiguration: IEntityTypeConfiguration<AbonentType>
{
    public void Configure(EntityTypeBuilder<AbonentType> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(20);
        builder.HasMany(x => x.Abonents)
            .WithOne(a => a.AbonentType)
            .HasForeignKey(x => x.AbonentTypeId);
    }
}