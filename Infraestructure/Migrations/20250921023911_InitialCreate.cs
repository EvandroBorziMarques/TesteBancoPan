using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Unidade = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Localidade = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Uf = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Regiao = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Ibge = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gia = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DDD = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    Siafi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    TipoPessoa = table.Column<int>(type: "int", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    RazaoSocial = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_EnderecoId",
                table: "Pessoas",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "Enderecos");
        }
    }
}
