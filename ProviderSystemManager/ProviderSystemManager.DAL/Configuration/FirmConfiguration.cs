using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;

public class FirmConfiguration : IEntityTypeConfiguration<Firm>
{
    public void Configure(EntityTypeBuilder<Firm> builder)
    {
        builder.ToTable("firms");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name)
            .HasColumnName("name")
            .HasMaxLength(40);
        builder.Property(x => x.Telephone)
            .HasColumnName("telephone")
            .HasMaxLength(15);
        builder.Property(x => x.Address)
            .HasColumnName("address")
            .HasMaxLength(30);
        builder.Property(x => x.OwnTypeId)
            .HasColumnName("own_type_id");
        builder.Property(x => x.StartWorkingYear)
            .HasColumnName("start_working_year");
    }
}