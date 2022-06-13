using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Configuration;
using ProviderSystemManager.DAL.Models;

namespace ProviderSystemManager.DAL.Database;

public class ProviderDbContext : DbContext
{
    public ProviderDbContext() : base() { }
    public ProviderDbContext(DbContextOptions<ProviderDbContext> options) : base(options) { }
    public DbSet<OwnType> OwnTypes { get; set; }
    public DbSet<AbonentType> AbonentTypes { get; set; }
    public DbSet<Abonent> Abonents { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Firm> Firms { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OwnTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AbonentTypeConfiguration());
        modelBuilder.ApplyConfiguration(new AbonentConfiguration());
        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new FirmConfiguration());
        modelBuilder.ApplyConfiguration(new ContractConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder builder)
    //{
    //    builder.UseNpgsql("User ID=postgres;Password=1956;Host=localhost;Port=5432;Database=ProviderSM;Pooling=true;");
    //}
}