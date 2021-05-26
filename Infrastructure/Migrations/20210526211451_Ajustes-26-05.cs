using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Ajustes2605 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    IdConta = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TipoDespesas = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.IdConta);
                    table.ForeignKey(
                        name: "FK_Conta_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LogSistemas",
                columns: table => new
                {
                    IdLogSistema = table.Column<string>(nullable: false),
                    JsonInformacao = table.Column<string>(nullable: true),
                    TipoLog = table.Column<int>(nullable: false),
                    NomeController = table.Column<string>(nullable: true),
                    NomeAction = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogSistemas", x => x.IdLogSistema);
                    table.ForeignKey(
                        name: "FK_LogSistemas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_UserId",
                table: "Conta",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LogSistemas_UserId",
                table: "LogSistemas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "LogSistemas");
        }
    }
}
