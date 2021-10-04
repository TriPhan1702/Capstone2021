using Microsoft.EntityFrameworkCore.Migrations;

namespace HairCutAppAPI.Data.Migrations
{
    public partial class ChangeCombosServicesToComboDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CombosServices_Combos_ComboId",
                table: "CombosServices");

            migrationBuilder.DropForeignKey(
                name: "FK_CombosServices_Services_ServiceId",
                table: "CombosServices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CombosServices",
                table: "CombosServices");

            migrationBuilder.RenameTable(
                name: "CombosServices",
                newName: "ComboDetails");

            migrationBuilder.RenameIndex(
                name: "IX_CombosServices_ServiceId",
                table: "ComboDetails",
                newName: "IX_ComboDetails_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_CombosServices_ComboId",
                table: "ComboDetails",
                newName: "IX_ComboDetails_ComboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComboDetails",
                table: "ComboDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDetails_Combos_ComboId",
                table: "ComboDetails",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComboDetails_Services_ServiceId",
                table: "ComboDetails",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComboDetails_Combos_ComboId",
                table: "ComboDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ComboDetails_Services_ServiceId",
                table: "ComboDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComboDetails",
                table: "ComboDetails");

            migrationBuilder.RenameTable(
                name: "ComboDetails",
                newName: "CombosServices");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDetails_ServiceId",
                table: "CombosServices",
                newName: "IX_CombosServices_ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ComboDetails_ComboId",
                table: "CombosServices",
                newName: "IX_CombosServices_ComboId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CombosServices",
                table: "CombosServices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CombosServices_Combos_ComboId",
                table: "CombosServices",
                column: "ComboId",
                principalTable: "Combos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CombosServices_Services_ServiceId",
                table: "CombosServices",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
