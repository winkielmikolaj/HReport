using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HReport.Migrations
{
    /// <inheritdoc />
    public partial class SeedingeTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Complaint = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsChecked = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoReports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "InfoReports",
                columns: new[] { "Id", "Complaint", "Date", "Description", "IsChecked" },
                values: new object[,]
                {
                    { 1, "Complaint 1", new DateTime(2024, 9, 17, 12, 12, 5, 906, DateTimeKind.Utc).AddTicks(4482), "Description 1", false },
                    { 2, "Complaint 2", new DateTime(2024, 9, 17, 12, 12, 5, 906, DateTimeKind.Utc).AddTicks(4488), "Description 2", false },
                    { 3, "Complaint 3", new DateTime(2024, 9, 17, 12, 12, 5, 906, DateTimeKind.Utc).AddTicks(4489), "Description 3", false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoReports");
        }
    }
}
