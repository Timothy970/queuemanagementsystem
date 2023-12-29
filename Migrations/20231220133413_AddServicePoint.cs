using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace assignmentapp.Migrations
{
    /// <inheritdoc />
    public partial class AddServicePoint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServicePointId",
                table: "Customers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServicePoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicePoints", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ServicePointId",
                table: "Customers",
                column: "ServicePointId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_ServicePoints_ServicePointId",
                table: "Customers",
                column: "ServicePointId",
                principalTable: "ServicePoints",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_ServicePoints_ServicePointId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "ServicePoints");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ServicePointId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ServicePointId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");
        }
    }
}
