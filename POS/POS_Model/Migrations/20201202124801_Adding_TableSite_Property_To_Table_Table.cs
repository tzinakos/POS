using Microsoft.EntityFrameworkCore.Migrations;

namespace POS_Model.Migrations
{
    public partial class Adding_TableSite_Property_To_Table_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TableSite",
                table: "Tables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TableSite",
                table: "Tables");
        }
    }
}
