using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class FinishOrder02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Citys_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses");

            migrationBuilder.AlterColumn<long>(
                name: "ProvinceId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Addresses",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Citys_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Citys_CityId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses");

            migrationBuilder.AlterColumn<long>(
                name: "ProvinceId",
                table: "Addresses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "CityId",
                table: "Addresses",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Citys_CityId",
                table: "Addresses",
                column: "CityId",
                principalTable: "Citys",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Provinces_ProvinceId",
                table: "Addresses",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "ProvinceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
