using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Configuration;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Login)
            .IsUnique();
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Role).HasColumnName("role");
        builder.Property(x => x.Login)
            .HasColumnName("login")
            .IsRequired()
            .HasMaxLength(20);
        builder.Property(x => x.Password)
            .HasColumnName("password")
            .IsRequired()
            .HasMaxLength(150);
    }
}