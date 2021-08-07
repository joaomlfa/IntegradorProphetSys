using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegradorSV.Migrations
{
    public partial class atualiacao_tabela_usr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "usr_senha",
                table: "Usuario",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "usr_senha",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);
        }
    }
}
