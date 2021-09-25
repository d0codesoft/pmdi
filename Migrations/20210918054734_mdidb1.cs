using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace pmdi.Migrations
{
    public partial class mdidb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisPatientsDoc_DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc",
                column: "DiagnosisPatientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisPatientsDoc_DiagnosisPatients_DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc",
                column: "DiagnosisPatientsId",
                principalTable: "DiagnosisPatients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisPatientsDoc_DiagnosisPatients_DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc");

            migrationBuilder.DropIndex(
                name: "IX_DiagnosisPatientsDoc_DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc");

            migrationBuilder.DropColumn(
                name: "DiagnosisPatientsId",
                table: "DiagnosisPatientsDoc");
        }
    }
}
