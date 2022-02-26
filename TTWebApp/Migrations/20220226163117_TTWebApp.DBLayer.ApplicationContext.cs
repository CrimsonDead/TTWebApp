using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TTWebApp.Migrations
{
    public partial class TTWebAppDBLayerApplicationContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: true),
                    NumberOfPurchase = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<float>(type: "real", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    NumberOfPurchase = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "DateOfCreation", "Name", "NickName" },
                values: new object[] { 1, 12, new DateTime(2002, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "SaneKing" });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "DateOfCreation", "Name", "NickName" },
                values: new object[] { 2, 20, new DateTime(2002, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kir", "CrimsonDead" });

            migrationBuilder.InsertData(
                table: "Photos",
                columns: new[] { "Id", "AuthorId", "Cost", "DateOfCreation", "Link", "Name", "NumberOfPurchase", "Size" },
                values: new object[,]
                {
                    { 1, 1, 5f, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ya.cc/t/bvybNZ4V3FerDY", "Red House", 79, 123f },
                    { 2, 1, 88f, new DateTime(2021, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ya.cc/t/Ny1sR0Cl3Ferdt", "Nature", 2, 432f },
                    { 3, 2, 44f, new DateTime(2021, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "https://ya.cc/t/75GdCcRs3Ferjc", "Green field", 1, 2234f }
                });

            migrationBuilder.InsertData(
                table: "Texts",
                columns: new[] { "Id", "AuthorId", "Content", "Cost", "DateOfCreation", "NumberOfPurchase", "Size" },
                values: new object[] { 1, 2, "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi scelerisque dapibus magna at blandit. Sed efficitur ultricies ipsum eget lobortis. Nullam facilisis porta sapien, in sodales erat commodo eu. Duis nisl velit, pharetra id nisi vel, hendrerit varius massa. Cras pellentesque imperdiet est, at bibendum nisl ullamcorper id. Vestibulum commodo sagittis leo, vel feugiat lorem euismod ac. Praesent ac odio nulla. Sed pharetra et ipsum sit amet accumsan. Aliquam erat volutpat. ", 44f, new DateTime(2022, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 213f });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_AuthorId",
                table: "Photos",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_AuthorId",
                table: "Texts",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
