using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.ToTable("contracts");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasOne(x => x.Firm)
            .WithMany(f => f.Contracts)
            .HasForeignKey(f => f.FirmId);
        builder.HasOne(x => x.Abonent)
            .WithMany(f => f.Contracts)
            .HasForeignKey(f => f.AbonentId);
        builder.Property(x => x.ConnectionCost)
            .HasColumnName("connection_cost")
            .IsRequired();
        builder.Property(x => x.ConnectionDate)
            .HasColumnName("connection_date")
            .IsRequired();
        builder.Property(x => x.ForwardingCost)
            .HasColumnName("forwarding_cost")
            .IsRequired();
        builder.Property(x => x.AbonentId).HasColumnName("abonent_id");
        builder.Property(x => x.FirmId).HasColumnName("firm_id");
    }
}