using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Todos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    completed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Todos", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Todos",
                columns: new[] { "id", "completed_at", "created_at", "description", "IsCompleted", "title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 7, 29, 16, 58, 55, 739, DateTimeKind.Utc).AddTicks(5237), "Master Entity Framework Core with PostgreSQL", false, "Learn EF Core" },
                    { 2, new DateTime(2025, 7, 29, 16, 58, 55, 739, DateTimeKind.Utc).AddTicks(5787), new DateTime(2025, 7, 28, 16, 58, 55, 739, DateTimeKind.Utc).AddTicks(5709), "Create a RESTful API with CRUD operations", true, "Build Todo API" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_todos_created_at",
                table: "Todos",
                column: "created_at");

            migrationBuilder.CreateIndex(
                name: "ix_todos_is_completed",
                table: "Todos",
                column: "completed_at");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Todos");
        }
    }
}
