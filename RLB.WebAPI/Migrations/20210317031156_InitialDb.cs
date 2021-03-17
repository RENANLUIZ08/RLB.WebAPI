using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.RLB.WebAPI.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastro.Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro.Pessoas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro.Contatos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro.Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro.Contatos_Cadastro.Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Cadastro.Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro.Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complemento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PessoaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro.Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro.Enderecos_Cadastro.Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Cadastro.Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro.PessoaFisica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro.PessoaFisica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro.PessoaFisica_Cadastro.Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Cadastro.Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro.PessoaJuridica",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    im = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    proprietario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro.PessoaJuridica", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cadastro.PessoaJuridica_Cadastro.Pessoas_Id",
                        column: x => x.Id,
                        principalTable: "Cadastro.Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PFisicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PJuridicaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_Cadastro.PessoaFisica_PFisicaId",
                        column: x => x.PFisicaId,
                        principalTable: "Cadastro.PessoaFisica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Cadastro.PessoaJuridica_PJuridicaId",
                        column: x => x.PJuridicaId,
                        principalTable: "Cadastro.PessoaJuridica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro.Contatos_PessoaId",
                table: "Cadastro.Contatos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro.Enderecos_PessoaId",
                table: "Cadastro.Enderecos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PFisicaId",
                table: "Cliente",
                column: "PFisicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PJuridicaId",
                table: "Cliente",
                column: "PJuridicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastro.Contatos");

            migrationBuilder.DropTable(
                name: "Cadastro.Enderecos");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Cadastro.PessoaFisica");

            migrationBuilder.DropTable(
                name: "Cadastro.PessoaJuridica");

            migrationBuilder.DropTable(
                name: "Cadastro.Pessoas");
        }
    }
}
