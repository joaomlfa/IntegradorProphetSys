using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegradorSV.Migrations
{
    public partial class AtualicaoSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "usr_token_suasvendas",
                table: "Usuario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usr_salt",
                table: "Usuario",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "usr_salt",
                table: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "usr_token_suasvendas",
                table: "Usuario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
