using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace playground.Migrations
{
    public partial class migration24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repositories_Users_Userid",
                table: "Repositories");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "nickname",
                table: "Users",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "prior",
                table: "Tasks",
                newName: "Prior");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tasks",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "desc",
                table: "Tasks",
                newName: "Desc");

            migrationBuilder.RenameColumn(
                name: "deadline",
                table: "Tasks",
                newName: "Deadline");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tasks",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Tasks",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Repositories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Userid",
                table: "Repositories",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Repositories",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Repositories_Userid",
                table: "Repositories",
                newName: "IX_Repositories_UserId");

            migrationBuilder.AddColumn<int>(
                name: "RepositoryId",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Repositories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Repositories_Users_UserId",
                table: "Repositories",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repositories_Users_UserId",
                table: "Repositories");

            migrationBuilder.DropColumn(
                name: "RepositoryId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Users",
                newName: "nickname");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Prior",
                table: "Tasks",
                newName: "prior");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Desc",
                table: "Tasks",
                newName: "desc");

            migrationBuilder.RenameColumn(
                name: "Deadline",
                table: "Tasks",
                newName: "deadline");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tasks",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Tasks",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Repositories",
                newName: "Userid");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Repositories",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Repositories",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Repositories_UserId",
                table: "Repositories",
                newName: "IX_Repositories_Userid");

            migrationBuilder.AlterColumn<int>(
                name: "Userid",
                table: "Repositories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Repositories_Users_Userid",
                table: "Repositories",
                column: "Userid",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
