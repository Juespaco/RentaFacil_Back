using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInitalDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TblAgencies",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAgencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblClients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblClients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblVehicleTypes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TblEmployees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblEmployees_TblAgencies_AgencyId",
                        column: x => x.AgencyId,
                        principalSchema: "dbo",
                        principalTable: "TblAgencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblVehicles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblVehicles_TblVehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalSchema: "dbo",
                        principalTable: "TblVehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblBookingEmployeePerDays",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    day = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingsNumber = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBookingEmployeePerDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBookingEmployeePerDays_TblEmployees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalSchema: "dbo",
                        principalTable: "TblEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblBookings",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblBookings_TblClients_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "dbo",
                        principalTable: "TblClients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblBookings_TblEmployees_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "dbo",
                        principalTable: "TblEmployees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TblBookings_TblVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalSchema: "dbo",
                        principalTable: "TblVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblBookingEmployeePerDays_EmployeeId",
                schema: "dbo",
                table: "TblBookingEmployeePerDays",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_ClientId",
                schema: "dbo",
                table: "TblBookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_TblBookings_VehicleId",
                schema: "dbo",
                table: "TblBookings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_TblEmployees_AgencyId",
                schema: "dbo",
                table: "TblEmployees",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_TblVehicles_VehicleTypeId",
                schema: "dbo",
                table: "TblVehicles",
                column: "VehicleTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblBookingEmployeePerDays",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblBookings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblClients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblEmployees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblVehicles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblAgencies",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TblVehicleTypes",
                schema: "dbo");
        }
    }
}
