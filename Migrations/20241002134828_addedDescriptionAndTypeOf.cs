using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantBooking.Migrations
{
    /// <inheritdoc />
    public partial class addedDescriptionAndTypeOf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TypeOf",
                table: "MenuItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOf",
                table: "MenuItems");
        }
    }
}
