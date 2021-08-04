using Microsoft.EntityFrameworkCore.Migrations;

namespace klas_mvc.Data.Migrations
{
    public partial class addDepartmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Identity",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                schema: "Identity",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                schema: "Identity",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentID",
                schema: "Identity",
                table: "Courses",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentID",
                schema: "Identity",
                table: "AspNetUsers",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentID",
                schema: "Identity",
                table: "AspNetUsers",
                column: "DepartmentID",
                principalSchema: "Identity",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                schema: "Identity",
                table: "Courses",
                column: "DepartmentID",
                principalSchema: "Identity",
                principalTable: "Departments",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departments_DepartmentID",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentID",
                schema: "Identity",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "Departments",
                schema: "Identity");

            migrationBuilder.DropIndex(
                name: "IX_Courses_DepartmentID",
                schema: "Identity",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DepartmentID",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                schema: "Identity",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                schema: "Identity",
                table: "UserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
