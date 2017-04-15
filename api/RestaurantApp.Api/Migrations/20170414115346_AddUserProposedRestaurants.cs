using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantApp.Api.Migrations
{
    public partial class AddUserProposedRestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProposedRestaurant",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ProposedDate = table.Column<DateTime>(nullable: false),
                    RestaurantId = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProposedRestaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProposedRestaurant_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProposedRestaurant_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProposedRestaurant_RestaurantId",
                table: "UserProposedRestaurant",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProposedRestaurant_UserId",
                table: "UserProposedRestaurant",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProposedRestaurant");
        }
    }
}
