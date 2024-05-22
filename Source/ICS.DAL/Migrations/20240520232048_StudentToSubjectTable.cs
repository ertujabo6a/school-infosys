using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ICS.DAL.Migrations;

/// <inheritdoc />
public partial class StudentToSubjectTable : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "StudentEntitySubjectEntity");

        migrationBuilder.CreateTable(
            name: "studentToSubjects",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                SubjectId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_studentToSubjects", x => x.Id);
                table.ForeignKey(
                    name: "FK_studentToSubjects_Students_StudentId",
                    column: x => x.StudentId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_studentToSubjects_Subjects_SubjectId",
                    column: x => x.SubjectId,
                    principalTable: "Subjects",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.InsertData(
            table: "Students",
            columns: new[] { "Id", "ImageUrl", "Name", "Surname" },
            values: new object[,]
            {
                { new Guid("4b3702a3-6e75-473b-882b-1c15face46ea"), null, "Kamil", "Ajajaj" },
                { new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2c"), null, "Petr", "Novakov" }
            });

        migrationBuilder.InsertData(
            table: "Subjects",
            columns: new[] { "Id", "Abbr", "Credits", "Name" },
            values: new object[] { new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2d"), "ICS", 4, "The C# programming language" });

        migrationBuilder.InsertData(
            table: "Activities",
            columns: new[] { "Id", "Description", "EndTime", "Room", "StartTime", "SubjectId", "Type" },
            values: new object[] { new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2a"), null, new DateTime(2024, 2, 20, 13, 50, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2024, 2, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2d"), 1 });

        migrationBuilder.InsertData(
            table: "studentToSubjects",
            columns: new[] { "Id", "StudentId", "SubjectId" },
            values: new object[] { new Guid("fabde0cd-eefe-443f-baf6-1234cc2cbf2a"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2c"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2d") });

        migrationBuilder.InsertData(
            table: "Evaluations",
            columns: new[] { "Id", "ActivityId", "Description", "Points", "StudentId" },
            values: new object[,]
            {
                { new Guid("8f3f6551-5a7c-40ff-af05-6d7edd395736"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2a"), null, 3, new Guid("4b3702a3-6e75-473b-882b-1c15face46ea") },
                { new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2b"), new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2a"), null, 2, new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2c") }
            });

        migrationBuilder.CreateIndex(
            name: "IX_studentToSubjects_StudentId",
            table: "studentToSubjects",
            column: "StudentId");

        migrationBuilder.CreateIndex(
            name: "IX_studentToSubjects_SubjectId",
            table: "studentToSubjects",
            column: "SubjectId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "studentToSubjects");

        migrationBuilder.DeleteData(
            table: "Evaluations",
            keyColumn: "Id",
            keyValue: new Guid("8f3f6551-5a7c-40ff-af05-6d7edd395736"));

        migrationBuilder.DeleteData(
            table: "Evaluations",
            keyColumn: "Id",
            keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2b"));

        migrationBuilder.DeleteData(
            table: "Activities",
            keyColumn: "Id",
            keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2a"));

        migrationBuilder.DeleteData(
            table: "Students",
            keyColumn: "Id",
            keyValue: new Guid("4b3702a3-6e75-473b-882b-1c15face46ea"));

        migrationBuilder.DeleteData(
            table: "Students",
            keyColumn: "Id",
            keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2c"));

        migrationBuilder.DeleteData(
            table: "Subjects",
            keyColumn: "Id",
            keyValue: new Guid("fabde0cd-eefe-443f-baf6-3d96cc2cbf2d"));

        migrationBuilder.CreateTable(
            name: "StudentEntitySubjectEntity",
            columns: table => new
            {
                StudentsId = table.Column<Guid>(type: "TEXT", nullable: false),
                SubjectsId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StudentEntitySubjectEntity", x => new { x.StudentsId, x.SubjectsId });
                table.ForeignKey(
                    name: "FK_StudentEntitySubjectEntity_Students_StudentsId",
                    column: x => x.StudentsId,
                    principalTable: "Students",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_StudentEntitySubjectEntity_Subjects_SubjectsId",
                    column: x => x.SubjectsId,
                    principalTable: "Subjects",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_StudentEntitySubjectEntity_SubjectsId",
            table: "StudentEntitySubjectEntity",
            column: "SubjectsId");
    }
}
