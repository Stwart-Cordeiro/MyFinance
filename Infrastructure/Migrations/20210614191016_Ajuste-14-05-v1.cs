using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Ajuste1405v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlanoConta",
                columns: table => new
                {
                    IdPlanoConta = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    TipoDespesas = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanoConta", x => x.IdPlanoConta);
                    table.ForeignKey(
                        name: "FK_PlanoConta_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanoConta_UserId",
                table: "PlanoConta",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanoConta");
        }
    }
}
