using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectroTask.Migrations
{
    public partial class Initial_11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_ParentId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "People",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_ParentId",
                table: "People",
                column: "ParentId",
                principalTable: "People",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_People_ParentId",
                table: "People");

            migrationBuilder.AlterColumn<int>(
                name: "ParentId",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_People_People_ParentId",
                table: "People",
                column: "ParentId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
