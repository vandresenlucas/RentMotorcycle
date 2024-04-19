using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentMotorcycle.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateDeliveryman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveryman",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdentifyCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Cnpj = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LicenseDriverNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    LicenseType = table.Column<int>(type: "integer", nullable: false),
                    LicenseImage = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveryman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveryman_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryman_Cnpj",
                table: "Deliveryman",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryman_LicenseDriverNumber",
                table: "Deliveryman",
                column: "LicenseDriverNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Deliveryman_UserId",
                table: "Deliveryman",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveryman");
        }
    }
}
