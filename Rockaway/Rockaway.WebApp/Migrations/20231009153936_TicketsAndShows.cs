using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rockaway.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class TicketsAndShows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserClaim<string>_IdentityUser_UserId",
                table: "IdentityUserClaim<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserLogin<string>_IdentityUser_UserId",
                table: "IdentityUserLogin<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityUser_UserId",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropForeignKey(
                name: "FK_IdentityUserToken<string>_IdentityUser_UserId",
                table: "IdentityUserToken<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserToken<string>",
                table: "IdentityUserToken<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserRole<string>",
                table: "IdentityUserRole<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserLogin<string>",
                table: "IdentityUserLogin<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUserClaim<string>",
                table: "IdentityUserClaim<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRoleClaim<string>",
                table: "IdentityRoleClaim<string>");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IdentityRole",
                table: "IdentityRole");

            migrationBuilder.DeleteData(
                table: "IdentityUser",
                keyColumn: "Id",
                keyValue: "f0b13a58-0c1f-4466-b423-e58d7ca23bfd");

            migrationBuilder.RenameTable(
                name: "IdentityUserToken<string>",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "IdentityUserRole<string>",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "IdentityUserLogin<string>",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "IdentityUserClaim<string>",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "IdentityUser",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "IdentityRoleClaim<string>",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "IdentityRole",
                newName: "AspNetRoles");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserRole<string>_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserLogin<string>_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityUserClaim<string>_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IdentityRoleClaim<string>_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeadlineArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => new { x.VenueId, x.Date });
                    table.ForeignKey(
                        name: "FK_Show_Artist_HeadlineArtistId",
                        column: x => x.HeadlineArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Show_Venue_VenueId",
                        column: x => x.VenueId,
                        principalTable: "Venue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportSlot",
                columns: table => new
                {
                    Position = table.Column<int>(type: "int", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportSlot", x => new { x.Position, x.ShowDate, x.ShowVenueId });
                    table.ForeignKey(
                        name: "FK_SupportSlot_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupportSlot_Show_ShowVenueId_ShowDate",
                        columns: x => new { x.ShowVenueId, x.ShowDate },
                        principalTable: "Show",
                        principalColumns: new[] { "VenueId", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketOrder",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketOrder_Show_ShowVenueId_ShowDate",
                        columns: x => new { x.ShowVenueId, x.ShowDate },
                        principalTable: "Show",
                        principalColumns: new[] { "VenueId", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    QuantityAvailable = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketType_Show_ShowVenueId_ShowDate",
                        columns: x => new { x.ShowVenueId, x.ShowDate },
                        principalTable: "Show",
                        principalColumns: new[] { "VenueId", "Date" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketOrder_OrderId",
                        column: x => x.OrderId,
                        principalTable: "TicketOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketType_TicketTypeId",
                        column: x => x.TicketTypeId,
                        principalTable: "TicketType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "rockaway-sample-admin-user", 0, "9d3dd3df-097b-40ad-bdb5-bd37a36559d8", "admin@rockaway.dev", true, true, null, "ADMIN@ROCKAWAY.DEV", "ADMIN@ROCKAWAY.DEV", "AQAAAAIAAYagAAAAECYZtAjsVEMyr9a5Jax3nh3MkZZOqPM5G8L1f6ZHZeeanL86NYiEN7hpjRNgLSisfA==", null, true, "9230f736-519d-4f48-a981-316016a53606", false, "admin@rockaway.dev" });

            migrationBuilder.InsertData(
                table: "Show",
                columns: new[] { "Date", "VenueId", "HeadlineArtistId" },
                values: new object[,]
                {
                    { new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
                    { new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
                    { new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
                    { new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
                    { new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") }
                });

            migrationBuilder.InsertData(
                table: "SupportSlot",
                columns: new[] { "Position", "ShowDate", "ShowVenueId", "ArtistId" },
                values: new object[,]
                {
                    { 0, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9") },
                    { 0, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9") },
                    { 0, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9") },
                    { 0, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9") },
                    { 0, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa9") },
                    { 1, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { 1, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { 1, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { 1, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") },
                    { 1, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaa10") }
                });

            migrationBuilder.InsertData(
                table: "TicketType",
                columns: new[] { "Id", "Name", "Price", "QuantityAvailable", "ShowDate", "ShowVenueId" },
                values: new object[,]
                {
                    { new Guid("dddddddd-dddd-dddd-dddd-dddddddddd10"), "Seated", 220m, 150, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd1"), "Standing", 25m, null, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd2"), "Seated", 20m, null, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd3"), "Standing", 25m, 100, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd4"), "Seated", 20m, 150, new DateTime(2023, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd5"), "Standing", 350m, 100, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd6"), "Seated", 250m, 150, new DateTime(2023, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd7"), "Standing", 400m, 100, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd8"), "Seated", 280m, 100, new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
                    { new Guid("dddddddd-dddd-dddd-dddd-ddddddddddd9"), "Standing", 270m, 100, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Show_HeadlineArtistId",
                table: "Show",
                column: "HeadlineArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSlot_ArtistId",
                table: "SupportSlot",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportSlot_ShowVenueId_ShowDate",
                table: "SupportSlot",
                columns: new[] { "ShowVenueId", "ShowDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_OrderId",
                table: "Ticket",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketTypeId",
                table: "Ticket",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketOrder_ShowVenueId_ShowDate",
                table: "TicketOrder",
                columns: new[] { "ShowVenueId", "ShowDate" });

            migrationBuilder.CreateIndex(
                name: "IX_TicketType_ShowVenueId_ShowDate",
                table: "TicketType",
                columns: new[] { "ShowVenueId", "ShowDate" });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "SupportSlot");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketOrder");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "rockaway-sample-admin-user");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "IdentityUserToken<string>");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "IdentityUser");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "IdentityUserRole<string>");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "IdentityUserLogin<string>");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "IdentityUserClaim<string>");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "IdentityRole");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "IdentityRoleClaim<string>");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "IdentityUserRole<string>",
                newName: "IX_IdentityUserRole<string>_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "IdentityUserLogin<string>",
                newName: "IX_IdentityUserLogin<string>_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "IdentityUserClaim<string>",
                newName: "IX_IdentityUserClaim<string>_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "IdentityRoleClaim<string>",
                newName: "IX_IdentityRoleClaim<string>_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserToken<string>",
                table: "IdentityUserToken<string>",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUser",
                table: "IdentityUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserRole<string>",
                table: "IdentityUserRole<string>",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserLogin<string>",
                table: "IdentityUserLogin<string>",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityUserClaim<string>",
                table: "IdentityUserClaim<string>",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRole",
                table: "IdentityRole",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IdentityRoleClaim<string>",
                table: "IdentityRoleClaim<string>",
                column: "Id");

            migrationBuilder.InsertData(
                table: "IdentityUser",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "f0b13a58-0c1f-4466-b423-e58d7ca23bfd", 0, "13c3a901-b3ef-4087-99bd-4838697f012d", "admin@rockaway.dev", true, true, null, "ADMIN@ROCKAWAY.DEV", "ADMIN@ROCKAWAY.DEV", "AQAAAAIAAYagAAAAECGG+Toa0zUk4MKymWLqGexZpAVx/jjWNP4hqqnNPCUKUhYUgo1Wpe0NlxJ26MiBgA==", null, true, "fe4ba7a6-7089-497d-a684-80bb5f8e19d1", false, "admin@rockaway.dev" });

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                table: "IdentityRoleClaim<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserClaim<string>_IdentityUser_UserId",
                table: "IdentityUserClaim<string>",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserLogin<string>_IdentityUser_UserId",
                table: "IdentityUserLogin<string>",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                table: "IdentityUserRole<string>",
                column: "RoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserRole<string>_IdentityUser_UserId",
                table: "IdentityUserRole<string>",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IdentityUserToken<string>_IdentityUser_UserId",
                table: "IdentityUserToken<string>",
                column: "UserId",
                principalTable: "IdentityUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
