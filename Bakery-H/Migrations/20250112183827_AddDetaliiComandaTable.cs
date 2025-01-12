using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bakery_H.Migrations
{
    /// <inheritdoc />
    public partial class AddDetaliiComandaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6718c45b-e37b-4d88-a1d4-0fadb0a0a319"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f8556adc-8794-4c5c-b1a7-bbd59ff973b7"));

            migrationBuilder.AlterColumn<string>(
                name: "Prenume",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumarTelefon",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocatieId",
                table: "FormulareAngajare",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "DetaliiComanda",
                columns: table => new
                {
                    IdDetaliiComanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdusId = table.Column<int>(type: "int", nullable: false),
                    ComandaId = table.Column<int>(type: "int", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiComanda", x => x.IdDetaliiComanda);
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_Comenzi_ComandaId",
                        column: x => x.ComandaId,
                        principalTable: "Comenzi",
                        principalColumn: "IdComanda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "IdProdus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("18911bd1-fa2a-4f7a-9fec-3561fb194d13"), null, "Administrator", "ADMINISTRATOR" },
                    { new Guid("900b6ae6-5daf-451b-ba79-e4769e79dba3"), null, "Client", "CLIENT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_ComandaId",
                table: "DetaliiComanda",
                column: "ComandaId");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_ProdusId",
                table: "DetaliiComanda",
                column: "ProdusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiComanda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("18911bd1-fa2a-4f7a-9fec-3561fb194d13"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("900b6ae6-5daf-451b-ba79-e4769e79dba3"));

            migrationBuilder.AlterColumn<string>(
                name: "Prenume",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nume",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NumarTelefon",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "LocatieId",
                table: "FormulareAngajare",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "FormulareAngajare",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6718c45b-e37b-4d88-a1d4-0fadb0a0a319"), null, "Client", "CLIENT" },
                    { new Guid("f8556adc-8794-4c5c-b1a7-bbd59ff973b7"), null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
