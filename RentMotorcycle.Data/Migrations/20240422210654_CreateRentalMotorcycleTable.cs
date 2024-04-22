using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentMotorcycle.Repository.Migrations
{
    /// <inheritdoc />
    public partial class CreateRentalMotorcycleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RentalMotorcycle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RentalPlanId = table.Column<Guid>(type: "uuid", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 50, nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 50, nullable: false),
                    EstimatedCompletionDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 100, nullable: false),
                    DeliverymanId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentalMotorcycle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RentalMotorcycle_Deliveryman_DeliverymanId",
                        column: x => x.DeliverymanId,
                        principalTable: "Deliveryman",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentalMotorcycle_RentalPlan_RentalPlanId",
                        column: x => x.RentalPlanId,
                        principalTable: "RentalPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentalMotorcycle_DeliverymanId",
                table: "RentalMotorcycle",
                column: "DeliverymanId");

            migrationBuilder.CreateIndex(
                name: "IX_RentalMotorcycle_RentalPlanId",
                table: "RentalMotorcycle",
                column: "RentalPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RentalMotorcycle");
        }
    }
}
