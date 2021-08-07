using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegradorSV.Migrations
{
    public partial class AtualizacaoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ultima_atualizacao_suasvendas",
                table: "Usuario",
                newName: "usr_ultima_atualizacao_suasvendas");

            migrationBuilder.RenameColumn(
                name: "ultima_atualizacao_pedidoeletronico",
                table: "Usuario",
                newName: "usr_ultima_atualizacao_pedidoeletronico");

            migrationBuilder.RenameColumn(
                name: "token_suasvendas",
                table: "Usuario",
                newName: "usr_token_suasvendas");

            migrationBuilder.RenameColumn(
                name: "token_pedido_eletronico",
                table: "Usuario",
                newName: "usr_token_pedido_eletronico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "usr_ultima_atualizacao_suasvendas",
                table: "Usuario",
                newName: "ultima_atualizacao_suasvendas");

            migrationBuilder.RenameColumn(
                name: "usr_ultima_atualizacao_pedidoeletronico",
                table: "Usuario",
                newName: "ultima_atualizacao_pedidoeletronico");

            migrationBuilder.RenameColumn(
                name: "usr_token_suasvendas",
                table: "Usuario",
                newName: "token_suasvendas");

            migrationBuilder.RenameColumn(
                name: "usr_token_pedido_eletronico",
                table: "Usuario",
                newName: "token_pedido_eletronico");
        }
    }
}
