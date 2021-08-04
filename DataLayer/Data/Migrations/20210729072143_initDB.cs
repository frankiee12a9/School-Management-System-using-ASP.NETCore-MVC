using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace klas_mvc.Data.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "AspNetUsers",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "UserTokens",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "UserRoles",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "UserLogins",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "UserClaims",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "Role",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "RoleClaims",
                newSchema: "Identity");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                newName: "IX_UserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                newName: "IX_UserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                newName: "IX_UserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                newName: "IX_RoleClaims_RoleId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserType",
                schema: "Identity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Courses",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    ClassPlace1 = table.Column<string>(nullable: false),
                    ClassPlace2 = table.Column<string>(nullable: false),
                    ClassTime1 = table.Column<string>(nullable: false),
                    ClassTime2 = table.Column<string>(nullable: false),
                    Week1 = table.Column<string>(nullable: true),
                    Week2 = table.Column<string>(nullable: true),
                    Week3 = table.Column<string>(nullable: true),
                    Week4 = table.Column<string>(nullable: true),
                    Week5 = table.Column<string>(nullable: true),
                    Week6 = table.Column<string>(nullable: true),
                    Week7 = table.Column<string>(nullable: true),
                    Week8 = table.Column<string>(nullable: true),
                    Week9 = table.Column<string>(nullable: true),
                    Week10 = table.Column<string>(nullable: true),
                    CourseName = table.Column<string>(nullable: true),
                    CourseType = table.Column<string>(nullable: true),
                    CourseCredit = table.Column<int>(nullable: false),
                    CourseDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseAssigments",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    LecturerId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAssigments", x => new { x.CourseId, x.LecturerId });
                    table.ForeignKey(
                        name: "FK_CourseAssigments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAssigments_AspNetUsers_LecturerId",
                        column: x => x.LecturerId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                schema: "Identity",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    StudentId = table.Column<string>(nullable: false),
                    EnrollmentId = table.Column<int>(nullable: false),
                    Grade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => new { x.CourseId, x.StudentId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "Identity",
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseFileUploads",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    FileType = table.Column<string>(nullable: true),
                    Extension = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UploadedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    Data = table.Column<byte[]>(nullable: true),
                    CourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseFileUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseFileUploads_Courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "Identity",
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseAssigments_LecturerId",
                schema: "Identity",
                table: "CourseAssigments",
                column: "LecturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_StudentId",
                schema: "Identity",
                table: "CourseEnrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseFileUploads_CourseId",
                schema: "Identity",
                table: "CourseFileUploads",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId",
                principalSchema: "Identity",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRoles",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoleClaims_Role_RoleId",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaims_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogins_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Role_RoleId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTokens_AspNetUsers_UserId",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropTable(
                name: "CourseAssigments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseEnrollments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "CourseFileUploads",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Courses",
                schema: "Identity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTokens",
                schema: "Identity",
                table: "UserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoles",
                schema: "Identity",
                table: "UserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserLogins",
                schema: "Identity",
                table: "UserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserClaims",
                schema: "Identity",
                table: "UserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RoleClaims",
                schema: "Identity",
                table: "RoleClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                schema: "Identity",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserType",
                schema: "Identity",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                schema: "Identity",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserTokens",
                schema: "Identity",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "UserRoles",
                schema: "Identity",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "UserLogins",
                schema: "Identity",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "UserClaims",
                schema: "Identity",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "RoleClaims",
                schema: "Identity",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "Role",
                schema: "Identity",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_UserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
