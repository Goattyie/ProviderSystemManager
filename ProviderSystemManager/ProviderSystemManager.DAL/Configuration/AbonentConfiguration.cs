using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class AbonentConfiguration : IEntityTypeConfiguration<Abonent>
{
    public void Configure(EntityTypeBuilder<Abonent> builder)
    {
        builder.ToTable("abonents");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .IsRequired();
        builder.HasIndex(x => x.Email).IsUnique();
        builder.Property(x => x.Email).HasColumnName("email");
        builder.HasIndex(x => x.Address).IsUnique();
        builder.Property(x => x.Address)
            .HasColumnName("address")
            .IsRequired();
        builder.Property(x => x.AbonentTypeId).HasColumnName("abonent_type_id");
        builder.HasMany(x => x.Services)
            .WithOne(a => a.Abonent);
        builder.HasOne(x => x.AbonentType)
            .WithMany(a => a.Abonents)
            .HasForeignKey(k => k.AbonentTypeId);
    }
}