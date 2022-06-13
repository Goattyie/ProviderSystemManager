using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.AbonentId).IsRequired();
        builder.HasOne(x => x.Abonent)
            .WithMany(a => a.Services)
            .HasForeignKey(k => k.AbonentId);
        builder.HasOne(x => x.Firm)
            .WithMany(m => m.Services)
            .HasForeignKey(k => k.FirmId);
        
    }
}