using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HW2_RentACar.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RentingDayDuration = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rents_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "ModelYear", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 2020, "Fiat", 250.0 },
                    { 2, 2019, "BMW", 350.0 },
                    { 3, 2021, "Mercedes", 350.0 },
                    { 4, 2018, "Ford", 200.0 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "İlker", "Baltacı" },
                    { 2, "Abuzer", "Kömürcü" },
                    { 3, "Eşref", "Bitlis" },
                    { 4, "Tombalacı", "Mehmet" }
                });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CarId", "ClientId", "CreatedAt", "RentingDayDuration", "TotalPrice" },
                values: new object[] { 1, 3, 1, new DateTime(2021, 10, 21, 12, 52, 25, 611, DateTimeKind.Local).AddTicks(702), 3, 1050.0 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CarId", "ClientId", "CreatedAt", "RentingDayDuration", "TotalPrice" },
                values: new object[] { 2, 1, 3, new DateTime(2021, 10, 21, 12, 52, 25, 613, DateTimeKind.Local).AddTicks(3742), 4, 1000.0 });

            migrationBuilder.InsertData(
                table: "Rents",
                columns: new[] { "Id", "CarId", "ClientId", "CreatedAt", "RentingDayDuration", "TotalPrice" },
                values: new object[] { 3, 4, 4, new DateTime(2021, 10, 21, 12, 52, 25, 613, DateTimeKind.Local).AddTicks(3774), 5, 1000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_CarId",
                table: "Rents",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ClientId",
                table: "Rents",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
