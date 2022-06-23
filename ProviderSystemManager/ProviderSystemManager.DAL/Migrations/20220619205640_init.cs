using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProviderSystemManager.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "abonent_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonent_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "own_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_own_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "abonents",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    address = table.Column<string>(type: "text", nullable: false),
                    abonent_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_abonents", x => x.id);
                    table.ForeignKey(
                        name: "FK_abonents_abonent_types_abonent_type_id",
                        column: x => x.abonent_type_id,
                        principalTable: "abonent_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "firms",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    telephone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    address = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    start_working_year = table.Column<short>(type: "smallint", nullable: false),
                    own_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_firms", x => x.id);
                    table.ForeignKey(
                        name: "FK_firms_own_types_own_type_id",
                        column: x => x.own_type_id,
                        principalTable: "own_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contracts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    firm_id = table.Column<int>(type: "integer", nullable: false),
                    abonent_id = table.Column<int>(type: "integer", nullable: false),
                    connection_date = table.Column<DateOnly>(type: "date", nullable: false),
                    connection_cost = table.Column<decimal>(type: "numeric", nullable: false),
                    forwarding_cost = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contracts", x => x.id);
                    table.ForeignKey(
                        name: "FK_contracts_abonents_abonent_id",
                        column: x => x.abonent_id,
                        principalTable: "abonents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_contracts_firms_firm_id",
                        column: x => x.firm_id,
                        principalTable: "firms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    abonent_id = table.Column<int>(type: "integer", nullable: false),
                    recieving_date = table.Column<DateOnly>(type: "date", nullable: false),
                    size = table.Column<double>(type: "double precision", nullable: false),
                    firm_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                    table.ForeignKey(
                        name: "FK_services_abonents_abonent_id",
                        column: x => x.abonent_id,
                        principalTable: "abonents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_services_firms_firm_id",
                        column: x => x.firm_id,
                        principalTable: "firms",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_abonents_abonent_type_id",
                table: "abonents",
                column: "abonent_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_abonents_address",
                table: "abonents",
                column: "address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_abonents_email",
                table: "abonents",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_contracts_abonent_id",
                table: "contracts",
                column: "abonent_id");

            migrationBuilder.CreateIndex(
                name: "IX_contracts_firm_id",
                table: "contracts",
                column: "firm_id");

            migrationBuilder.CreateIndex(
                name: "IX_firms_own_type_id",
                table: "firms",
                column: "own_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_abonent_id",
                table: "services",
                column: "abonent_id");

            migrationBuilder.CreateIndex(
                name: "IX_services_firm_id",
                table: "services",
                column: "firm_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contracts");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "abonents");

            migrationBuilder.DropTable(
                name: "firms");

            migrationBuilder.DropTable(
                name: "abonent_types");

            migrationBuilder.DropTable(
                name: "own_types");
        }
    }
}
