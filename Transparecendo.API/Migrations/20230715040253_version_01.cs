using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transparecendo.API.Migrations
{
    /// <inheritdoc />
    public partial class version_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorporateSpending",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CpfServidor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentoFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubElementoDespesa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDIC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presidente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mandato = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlImagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateSpending", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateSpending");
        }
    }
}
