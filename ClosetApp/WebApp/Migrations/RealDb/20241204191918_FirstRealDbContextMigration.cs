using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations.RealDb
{
    /// <inheritdoc />
    public partial class FirstRealDbContextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClothingItems",
                columns: table => new
                {
                    ClothingItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ClothingType = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    Design = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TopBaseClothingItem_Design = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClothingItems", x => x.ClothingItemId);
                });

            migrationBuilder.CreateTable(
                name: "Outfits",
                columns: table => new
                {
                    OutfitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outfits", x => x.OutfitId);
                });

            migrationBuilder.CreateTable(
                name: "OutfitClothingItem",
                columns: table => new
                {
                    OutfitClothesClothingItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutfitsOutfitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutfitClothingItem", x => new { x.OutfitClothesClothingItemId, x.OutfitsOutfitId });
                    table.ForeignKey(
                        name: "FK_OutfitClothingItem_ClothingItems_OutfitClothesClothingItemId",
                        column: x => x.OutfitClothesClothingItemId,
                        principalTable: "ClothingItems",
                        principalColumn: "ClothingItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OutfitClothingItem_Outfits_OutfitsOutfitId",
                        column: x => x.OutfitsOutfitId,
                        principalTable: "Outfits",
                        principalColumn: "OutfitId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OutfitClothingItem_OutfitsOutfitId",
                table: "OutfitClothingItem",
                column: "OutfitsOutfitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutfitClothingItem");

            migrationBuilder.DropTable(
                name: "ClothingItems");

            migrationBuilder.DropTable(
                name: "Outfits");
        }
    }
}
