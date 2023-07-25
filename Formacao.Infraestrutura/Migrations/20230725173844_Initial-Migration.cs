using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Formacao.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "formacao");

            migrationBuilder.CreateTable(
                name: "Formacao",
                schema: "formacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAlteracaoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAlteracaoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                schema: "formacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAlteracaoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAlteracaoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormacaoPessoa",
                schema: "formacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdPessoa = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFormacao = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CriadoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UltimaAlteracaoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UltimaAlteracaoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExcluidoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExcluidoPorIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormacaoPessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormacaoPessoa_Formacao_IdFormacao",
                        column: x => x.IdFormacao,
                        principalSchema: "formacao",
                        principalTable: "Formacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FormacaoPessoa_Pessoa_IdPessoa",
                        column: x => x.IdPessoa,
                        principalSchema: "formacao",
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoPessoa_IdFormacao",
                schema: "formacao",
                table: "FormacaoPessoa",
                column: "IdFormacao");

            migrationBuilder.CreateIndex(
                name: "IX_FormacaoPessoa_IdPessoa",
                schema: "formacao",
                table: "FormacaoPessoa",
                column: "IdPessoa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormacaoPessoa",
                schema: "formacao");

            migrationBuilder.DropTable(
                name: "Formacao",
                schema: "formacao");

            migrationBuilder.DropTable(
                name: "Pessoa",
                schema: "formacao");
        }
    }
}
