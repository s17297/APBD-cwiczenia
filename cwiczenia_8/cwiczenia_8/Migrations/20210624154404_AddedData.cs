using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cwiczenia_8.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "doktor1@bla.pl", "doktor1", "nazwiskodoktora1" },
                    { 2, "doktor2@bla.pl", "doktor2", "nazwiskodoktora2" },
                    { 3, "doktor3@bla.pl", "doktor3", "nazwiskodoktora3" },
                    { 4, "doktor4@bla.pl", "doktor4", "nazwiskodoktora4" }
                });

            migrationBuilder.InsertData(
                table: "Medicaments",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "opisleku1", "lek1", "typ1" },
                    { 2, "opisleku2", "lek2", "typ2" },
                    { 3, "opisleku3", "lek3", "typ3" },
                    { 4, "opisleku4", "lek4", "typ4" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "IdPatient", "Birthdate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(8921), "pacjent1", "nazwiskopacjenta1" },
                    { 2, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(115), "pacjent2", "nazwiskopacjenta2" },
                    { 3, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(166), "pacjent3", "nazwiskopacjenta3" },
                    { 4, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(172), "pacjent4", "nazwiskopacjenta4" }
                });

            migrationBuilder.InsertData(
                table: "Prescriptions",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(4565), new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(5087), 3, 1 },
                    { 4, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6526), new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6529), 1, 2 },
                    { 3, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6518), new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6522), 2, 3 },
                    { 2, new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6463), new DateTime(2021, 6, 24, 17, 44, 4, 125, DateTimeKind.Local).AddTicks(6488), 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "Prescription_Medicaments",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 4, 1, "szczegoly3", 2 },
                    { 2, 4, "szczegoly2", 4 },
                    { 3, 3, "szczegoly1", 3 },
                    { 1, 2, "szczegoly4", 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Prescription_Medicaments",
                keyColumns: new[] { "IdMedicament", "IdPrescription" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medicaments",
                keyColumn: "IdMedicament",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Prescriptions",
                keyColumn: "IdPrescription",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "IdDoctor",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "IdPatient",
                keyValue: 4);
        }
    }
}
