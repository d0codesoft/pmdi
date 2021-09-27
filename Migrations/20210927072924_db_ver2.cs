using Microsoft.EntityFrameworkCore.Migrations;

namespace pmdi.Migrations
{
    public partial class db_ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DosageDaily",
                table: "PatientMedicine",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DosageEvening",
                table: "PatientMedicine",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DosageLunch",
                table: "PatientMedicine",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DosageMorning",
                table: "PatientMedicine",
                type: "decimal(15,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DosageDaily",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DosageEvening",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DosageLunch",
                table: "PatientMedicine");

            migrationBuilder.DropColumn(
                name: "DosageMorning",
                table: "PatientMedicine");
        }
    }
}
