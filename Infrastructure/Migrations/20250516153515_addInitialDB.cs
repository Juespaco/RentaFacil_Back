using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addInitialDB : Migration
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
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    AgencyId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    BookingValuePerDay = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblAgencies",
                columns: new[] { "Id", "Address", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Cra 12 #45-67", new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2108), "seed", null, null, "Bogota", "3001234567" },
                    { 2, "Cra 55 #50-67", new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2111), "seed", null, null, "Medellin", "3001234568" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblClients",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FullName", "ModifiedAt", "ModifiedBy", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2247), "seed", "carlos@example.com", "Carlos Pérez", null, null, "3109876543" },
                    { 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2248), "seed", "maria.fernandez@example.com", "María Fernández", null, null, "3112345678" },
                    { 3, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2249), "seed", "juan.rodriguez@example.com", "Juan Rodríguez", null, null, "3123456789" },
                    { 4, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2251), "seed", "laura.mendez@example.com", "Laura Méndez", null, null, "3134567890" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblVehicleTypes",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2208), "seed", null, null, "Sedán" },
                    { 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2209), "seed", null, null, "SUV" },
                    { 3, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2211), "seed", null, null, "Camioneta" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblEmployees",
                columns: new[] { "Id", "AgencyId", "CreatedAt", "CreatedBy", "FullName", "ModifiedAt", "ModifiedBy", "Position" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2265), "seed", "Ana Torres", null, null, "Asesor" },
                    { 2, 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2266), "seed", "David Gómez", null, null, "Asesor" },
                    { 3, 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2267), "seed", "Santiago Ruiz", null, null, "Asesor" },
                    { 4, 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2290), "seed", "Camila López", null, null, "Asesor" }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblVehicles",
                columns: new[] { "Id", "BookingValuePerDay", "Brand", "CreatedAt", "CreatedBy", "Model", "ModifiedAt", "ModifiedBy", "PlateNumber", "VehicleTypeId", "Year" },
                values: new object[,]
                {
                    { 1, 100000, "Toyota", new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2230), "seed", "Corolla", null, null, "ABC123", 1, 2020 },
                    { 2, 150000, "Mazda", new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2232), "seed", "CX-5", null, null, "XYZ789", 2, 2022 }
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "TblBookings",
                columns: new[] { "Id", "ClientId", "CreatedAt", "CreatedBy", "EmployeeId", "EndDate", "ModifiedAt", "ModifiedBy", "StartDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2307), "seed", 0, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2309), "seed", 0, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2310), "seed", 0, new DateTime(2025, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, 4, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2311), "seed", 0, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, 1, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2312), "seed", 0, new DateTime(2025, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, 2, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2314), "seed", 0, new DateTime(2025, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, 3, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2315), "seed", 0, new DateTime(2025, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 8, 4, new DateTime(2025, 5, 16, 15, 35, 15, 496, DateTimeKind.Utc).AddTicks(2316), "seed", 0, new DateTime(2025, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, new DateTime(2025, 6, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
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
