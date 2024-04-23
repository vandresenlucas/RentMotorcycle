using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentMotorcycle.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateFiedlMotorcycleOnTableRentalMotorcycle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MotorcycleId",
                table: "RentalMotorcycle",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_RentalMotorcycle_MotorcycleId",
                table: "RentalMotorcycle",
                column: "MotorcycleId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentalMotorcycle_Motorcycle_MotorcycleId",
                table: "RentalMotorcycle",
                column: "MotorcycleId",
                principalTable: "Motorcycle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentalMotorcycle_Motorcycle_MotorcycleId",
                table: "RentalMotorcycle");

            migrationBuilder.DropIndex(
                name: "IX_RentalMotorcycle_MotorcycleId",
                table: "RentalMotorcycle");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "RentalMotorcycle");
        }
    }
}
