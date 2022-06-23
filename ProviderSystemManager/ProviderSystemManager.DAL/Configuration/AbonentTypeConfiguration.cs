using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class AbonentTypeConfiguration: IEntityTypeConfiguration<AbonentType>
{
    public void Configure(EntityTypeBuilder<AbonentType> builder)
    {
        builder.ToTable("abonent_types");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id");
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(20);
        builder.HasMany(x => x.Abonents)
            .WithOne(a => a.AbonentType)
            .HasForeignKey(x => x.AbonentTypeId);
    }
}