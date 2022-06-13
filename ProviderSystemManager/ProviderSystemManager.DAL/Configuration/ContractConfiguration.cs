using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Firm)
            .WithMany(f => f.Contracts)
            .HasForeignKey(f => f.FirmId);
        builder.HasOne(x => x.Abonent)
            .WithMany(f => f.Contracts)
            .HasForeignKey(f => f.AbonentId);
        builder.Property(x => x.ConnectionCost).IsRequired();
        builder.Property(x => x.ConnectionDate).IsRequired();
        builder.Property(x => x.ForwardingCost).IsRequired();
    }
}