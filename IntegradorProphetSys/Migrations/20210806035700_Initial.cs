using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegradorProphetSys.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usr_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    usr_nome = table.Column<string>(type: "text", nullable: false),
                    usr_email = table.Column<string>(type: "text", nullable: false),
                    usr_senha = table.Column<string>(type: "text", nullable: false),
                    usr_telefone = table.Column<string>(type: "text", nullable: false),
                    token_pedido_eletronico = table.Column<string>(type: "text", nullable: true),
                    token_suasvendas = table.Column<string>(type: "text", nullable: true),
                    ultima_atualizacao_suasvendas = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ultima_atualizacao_pedidoeletronico = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usr_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
