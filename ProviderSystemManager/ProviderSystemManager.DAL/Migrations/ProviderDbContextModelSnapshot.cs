// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProviderSystemManager.DAL.Database;

#nullable disable

namespace ProviderSystemManager.DAL.Migrations
{
    [DbContext(typeof(ProviderDbContext))]
    partial class ProviderDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Abonent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("abonent_type_id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.HasIndex("AbonentTypeId");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("abonents", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.AbonentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("abonent_types", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("integer")
                        .HasColumnName("abonent_id");

                    b.Property<decimal>("ConnectionCost")
                        .HasColumnType("numeric")
                        .HasColumnName("connection_cost");

                    b.Property<DateOnly>("ConnectionDate")
                        .HasColumnType("date")
                        .HasColumnName("connection_date");

                    b.Property<int>("FirmId")
                        .HasColumnType("integer")
                        .HasColumnName("firm_id");

                    b.Property<decimal>("ForwardingCost")
                        .HasColumnType("numeric")
                        .HasColumnName("forwarding_cost");

                    b.HasKey("Id");

                    b.HasIndex("AbonentId");

                    b.HasIndex("FirmId");

                    b.ToTable("contracts", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Firm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)")
                        .HasColumnName("name");

                    b.Property<int>("OwnTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("own_type_id");

                    b.Property<short>("StartWorkingYear")
                        .HasColumnType("smallint")
                        .HasColumnName("start_working_year");

                    b.Property<string>("Telephone")
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("telephone");

                    b.HasKey("Id");

                    b.HasIndex("OwnTypeId");

                    b.ToTable("firms", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.OwnType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("own_types", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AbonentId")
                        .HasColumnType("integer")
                        .HasColumnName("abonent_id");

                    b.Property<int>("FirmId")
                        .HasColumnType("integer")
                        .HasColumnName("firm_id");

                    b.Property<DateOnly>("RecievingDate")
                        .HasColumnType("date")
                        .HasColumnName("recieving_date");

                    b.Property<double>("Size")
                        .HasColumnType("double precision")
                        .HasColumnName("size");

                    b.HasKey("Id");

                    b.HasIndex("AbonentId");

                    b.HasIndex("FirmId");

                    b.ToTable("services", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.User", b =>
                {
                    b.Property<string>("Login")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("login");

                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.HasKey("Login");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Abonent", b =>
                {
                    b.HasOne("ProviderSystemManager.DAL.Models.AbonentType", "AbonentType")
                        .WithMany("Abonents")
                        .HasForeignKey("AbonentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbonentType");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Contract", b =>
                {
                    b.HasOne("ProviderSystemManager.DAL.Models.Abonent", "Abonent")
                        .WithMany("Contracts")
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProviderSystemManager.DAL.Models.Firm", "Firm")
                        .WithMany("Contracts")
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");

                    b.Navigation("Firm");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Firm", b =>
                {
                    b.HasOne("ProviderSystemManager.DAL.Models.OwnType", "OwnType")
                        .WithMany("Firms")
                        .HasForeignKey("OwnTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OwnType");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Service", b =>
                {
                    b.HasOne("ProviderSystemManager.DAL.Models.Abonent", "Abonent")
                        .WithMany("Services")
                        .HasForeignKey("AbonentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProviderSystemManager.DAL.Models.Firm", "Firm")
                        .WithMany("Services")
                        .HasForeignKey("FirmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Abonent");

                    b.Navigation("Firm");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Abonent", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.AbonentType", b =>
                {
                    b.Navigation("Abonents");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.Firm", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ProviderSystemManager.DAL.Models.OwnType", b =>
                {
                    b.Navigation("Firms");
                });
#pragma warning restore 612, 618
        }
    }
}
