using Microsoft.EntityFrameworkCore.Migrations;

namespace BP.EfCore.Data.Migrations
{
    public partial class CourseFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "courses",
                newName: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "courses",
                newName: "first_name");
        }
    }
}
