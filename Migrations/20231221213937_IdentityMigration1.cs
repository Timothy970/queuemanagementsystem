using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace assignmentapp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityMigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "ServiceProviders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "ServiceProviders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "ServiceProviders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "ServiceProviders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "ServiceProviders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "ServiceProviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "ServiceProviders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ServiceProviders",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "ServiceProviders");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ServiceProviders");
        }
    }
}
