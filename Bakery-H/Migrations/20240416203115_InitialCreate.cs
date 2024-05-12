using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bakery_H.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clienti",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clienti", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "Locatii",
                columns: table => new
                {
                    IdLocatie = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumarTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatii", x => x.IdLocatie);
                });

            migrationBuilder.CreateTable(
                name: "MetodePlata",
                columns: table => new
                {
                    IdMetodaPlata = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cash = table.Column<bool>(type: "bit", nullable: false),
                    Card = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetodePlata", x => x.IdMetodaPlata);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    IdProdus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ingrediente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cantitate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.IdProdus);
                });

            migrationBuilder.CreateTable(
                name: "Angajati",
                columns: table => new
                {
                    IdAngajat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Functie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataAngajarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumarTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocatieId = table.Column<int>(type: "int", nullable: false),
                    FormulareAngajareId = table.Column<int>(type: "int", nullable: true),
                    ComandaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajati", x => x.IdAngajat);
                    table.ForeignKey(
                        name: "FK_Angajati_Locatii_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locatii",
                        principalColumn: "IdLocatie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    IdComanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPlata = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MetodaPlataId = table.Column<int>(type: "int", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.IdComanda);
                    table.ForeignKey(
                        name: "FK_Comenzi_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "IdAngajat",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comenzi_Clienti_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clienti",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comenzi_MetodePlata_MetodaPlataId",
                        column: x => x.MetodaPlataId,
                        principalTable: "MetodePlata",
                        principalColumn: "IdMetodaPlata",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FormulareAngajare",
                columns: table => new
                {
                    IdFormular = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumarTelefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocatieId = table.Column<int>(type: "int", nullable: false),
                    AngajatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormulareAngajare", x => x.IdFormular);
                    table.ForeignKey(
                        name: "FK_FormulareAngajare_Angajati_AngajatId",
                        column: x => x.AngajatId,
                        principalTable: "Angajati",
                        principalColumn: "IdAngajat",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormulareAngajare_Locatii_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locatii",
                        principalColumn: "IdLocatie",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_FormulareAngajareId",
                table: "Angajati",
                column: "FormulareAngajareId");

            migrationBuilder.CreateIndex(
                name: "IX_Angajati_LocatieId",
                table: "Angajati",
                column: "LocatieId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_AngajatId",
                table: "Comenzi",
                column: "AngajatId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_ClientId",
                table: "Comenzi",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_MetodaPlataId",
                table: "Comenzi",
                column: "MetodaPlataId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulareAngajare_AngajatId",
                table: "FormulareAngajare",
                column: "AngajatId");

            migrationBuilder.CreateIndex(
                name: "IX_FormulareAngajare_LocatieId",
                table: "FormulareAngajare",
                column: "LocatieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Angajati_FormulareAngajare_FormulareAngajareId",
                table: "Angajati",
                column: "FormulareAngajareId",
                principalTable: "FormulareAngajare",
                principalColumn: "IdFormular");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Angajati_FormulareAngajare_FormulareAngajareId",
                table: "Angajati");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Clienti");

            migrationBuilder.DropTable(
                name: "MetodePlata");

            migrationBuilder.DropTable(
                name: "FormulareAngajare");

            migrationBuilder.DropTable(
                name: "Angajati");

            migrationBuilder.DropTable(
                name: "Locatii");
        }
    }
}
