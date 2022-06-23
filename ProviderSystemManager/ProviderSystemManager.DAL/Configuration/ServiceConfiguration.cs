using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("services");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.AbonentId)
            .HasColumnName("abonent_id")
            .IsRequired();
        builder.Property(x => x.Size)
            .HasColumnName("size");
        builder.Property(x => x.FirmId)
            .HasColumnName("firm_id");
        builder.Property(x => x.RecievingDate)
            .HasColumnName("recieving_date");
        builder.HasOne(x => x.Abonent)
            .WithMany(a => a.Services)
            .HasForeignKey(k => k.AbonentId);
        builder.HasOne(x => x.Firm)
            .WithMany(m => m.Services)
            .HasForeignKey(k => k.FirmId);
        
    }
}