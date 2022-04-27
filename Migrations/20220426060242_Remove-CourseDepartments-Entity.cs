using Microsoft.EntityFrameworkCore.Migrations;

namespace UniversityModel.Migrations
{
    public partial class RemoveCourseDepartmentsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CourseId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentId",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "CourseDepartment",
                newName: "DepartmentsId");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "CourseDepartment",
                newName: "CoursesId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "DepartmentsId",
                table: "CourseDepartment",
                newName: "DepartmentId");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseDepartment",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseDepartment_DepartmentsId",
                table: "CourseDepartment",
                newName: "IX_CourseDepartment_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CourseId",
                table: "CourseDepartment",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentId",
                table: "CourseDepartment",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
