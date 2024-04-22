using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentMotorcycle.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AlterPerfiltoProfileTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "User",
                newName: "Profile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Profile",
                table: "User",
                newName: "Perfil");
        }
    }
}
