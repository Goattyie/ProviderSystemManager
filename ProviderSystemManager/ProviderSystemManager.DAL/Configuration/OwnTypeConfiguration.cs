using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class OwnTypeConfiguration : IEntityTypeConfiguration<OwnType>
{
    public void Configure(EntityTypeBuilder<OwnType> builder)
    {
        builder.ToTable("own_types");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(20);
        builder.HasMany(x => x.Firms)
            .WithOne(m => m.OwnType)
            .HasForeignKey(k => k.OwnTypeId);
    }
}