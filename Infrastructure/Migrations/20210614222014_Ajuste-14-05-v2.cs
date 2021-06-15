using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Ajuste1405v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    IdTransacoes = table.Column<string>(nullable: false),
                    DataTransacao = table.Column<DateTime>(nullable: false),
                    TipoDespesas = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(9,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: true),
                    ContaId = table.Column<string>(nullable: true),
                    PlanoContaId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.IdTransacoes);
                    table.ForeignKey(
                        name: "FK_Transacao_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_PlanoConta_PlanoContaId",
                        column: x => x.PlanoContaId,
                        principalTable: "PlanoConta",
                        principalColumn: "IdPlanoConta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transacao_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ContaId",
                table: "Transacao",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_PlanoContaId",
                table: "Transacao",
                column: "PlanoContaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_UserId",
                table: "Transacao",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");
        }
    }
}
