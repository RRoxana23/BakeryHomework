using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bakery_H.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18911bd1-fa2a-4f7a-9fec-3561fb194d13"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("900b6ae6-5daf-451b-ba79-e4769e79dba3"));

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "Comenzi",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "IdClient",
                table: "Clienti",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ca884f5e-fc36-40c9-b226-bad86481e286"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("e6f6a04e-4306-44ea-bfcb-d50fd3c0f501"), null, "Client", "CLIENT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ca884f5e-fc36-40c9-b226-bad86481e286"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e6f6a04e-4306-44ea-bfcb-d50fd3c0f501"));

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Comenzi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "IdClient",
                table: "Clienti",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18911bd1-fa2a-4f7a-9fec-3561fb194d13"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("900b6ae6-5daf-451b-ba79-e4769e79dba3"), null, "Client", "CLIENT" }
                });
        }
    }
}
