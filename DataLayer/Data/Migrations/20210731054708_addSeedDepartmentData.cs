using Microsoft.EntityFrameworkCore.Migrations;

namespace klas_mvc.Data.Migrations
{
    public partial class addSeedDepartmentData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[] { 2201, "Computer Science Dept" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[] { 2202, "Mathematics Dept" });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Departments",
                columns: new[] { "DepartmentID", "DepartmentName" },
                values: new object[] { 2203, "Language and Trade Dept" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2201);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2202);

            migrationBuilder.DeleteData(
                schema: "Identity",
                table: "Departments",
                keyColumn: "DepartmentID",
                keyValue: 2203);
        }
    }
}
