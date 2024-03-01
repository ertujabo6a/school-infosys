using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ICS.DAL.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "OneOffActivities",
            columns: table => new
            {
                ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                ActivityDate = table.Column<DateOnly>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_OneOffActivities", x => x.ActivityId);
            });

        migrationBuilder.CreateTable(
            name: "PeriodicActivities",
            columns: table => new
            {
                ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                Day = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PeriodicActivities", x => x.ActivityId);
            });

        migrationBuilder.CreateTable(
            name: "Rooms",
            columns: table => new
            {
                RoomName = table.Column<string>(type: "TEXT", nullable: false),
                Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                Floor = table.Column<int>(type: "INTEGER", nullable: false),
                Purpose = table.Column<string>(type: "TEXT", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Rooms", x => x.RoomName);
            });

        migrationBuilder.CreateTable(
            name: "Subjects",
            columns: table => new
            {
                Abbr = table.Column<string>(type: "TEXT", nullable: false),
                Name = table.Column<string>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                Year = table.Column<int>(type: "INTEGER", nullable: false),
                Points = table.Column<int>(type: "INTEGER", nullable: false),
                Compulsorily = table.Column<bool>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Subjects", x => x.Abbr);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Login = table.Column<string>(type: "TEXT", nullable: false),
                Password = table.Column<string>(type: "TEXT", nullable: false),
                FirstName = table.Column<string>(type: "TEXT", nullable: false),
                LastName = table.Column<string>(type: "TEXT", nullable: false),
                Birth = table.Column<DateTime>(type: "TEXT", nullable: false),
                PhotoUrl = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Login);
            });

        migrationBuilder.CreateTable(
            name: "PeriodicActivityDates",
            columns: table => new
            {
                ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                IdNumber = table.Column<int>(type: "INTEGER", nullable: false),
                PeriodicActivityActivityId = table.Column<Guid>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PeriodicActivityDates", x => x.ActivityId);
                table.ForeignKey(
                    name: "FK_PeriodicActivityDates_PeriodicActivities_PeriodicActivityActivityId",
                    column: x => x.PeriodicActivityActivityId,
                    principalTable: "PeriodicActivities",
                    principalColumn: "ActivityId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Admins",
            columns: table => new
            {
                UserLogin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Admins", x => x.UserLogin);
                table.ForeignKey(
                    name: "FK_Admins_Users_UserLogin",
                    column: x => x.UserLogin,
                    principalTable: "Users",
                    principalColumn: "Login",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Students",
            columns: table => new
            {
                UserLogin = table.Column<string>(type: "TEXT", nullable: false),
                Year = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Students", x => x.UserLogin);
                table.ForeignKey(
                    name: "FK_Students_Users_UserLogin",
                    column: x => x.UserLogin,
                    principalTable: "Users",
                    principalColumn: "Login",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Teachers",
            columns: table => new
            {
                UserLogin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Teachers", x => x.UserLogin);
                table.ForeignKey(
                    name: "FK_Teachers_Users_UserLogin",
                    column: x => x.UserLogin,
                    principalTable: "Users",
                    principalColumn: "Login",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "StudentSubject",
            columns: table => new
            {
                StudentsUserLogin = table.Column<string>(type: "TEXT", nullable: false),
                SubjectsAbbr = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_StudentSubject", x => new { x.StudentsUserLogin, x.SubjectsAbbr });
                table.ForeignKey(
                    name: "FK_StudentSubject_Students_StudentsUserLogin",
                    column: x => x.StudentsUserLogin,
                    principalTable: "Students",
                    principalColumn: "UserLogin",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_StudentSubject_Subjects_SubjectsAbbr",
                    column: x => x.SubjectsAbbr,
                    principalTable: "Subjects",
                    principalColumn: "Abbr",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Activities",
            columns: table => new
            {
                EntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                ActivityName = table.Column<string>(type: "TEXT", nullable: false),
                StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: false),
                SubjectAbbr = table.Column<string>(type: "TEXT", nullable: false),
                TeacherUserLogin = table.Column<string>(type: "TEXT", nullable: false),
                TeacherLogin = table.Column<string>(type: "TEXT", nullable: false),
                RoomName = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Activities", x => x.EntityId);
                table.ForeignKey(
                    name: "FK_Activities_OneOffActivities_EntityId",
                    column: x => x.EntityId,
                    principalTable: "OneOffActivities",
                    principalColumn: "ActivityId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Activities_PeriodicActivities_EntityId",
                    column: x => x.EntityId,
                    principalTable: "PeriodicActivities",
                    principalColumn: "ActivityId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Activities_Rooms_RoomName",
                    column: x => x.RoomName,
                    principalTable: "Rooms",
                    principalColumn: "RoomName");
                table.ForeignKey(
                    name: "FK_Activities_Subjects_SubjectAbbr",
                    column: x => x.SubjectAbbr,
                    principalTable: "Subjects",
                    principalColumn: "Abbr");
                table.ForeignKey(
                    name: "FK_Activities_Teachers_TeacherUserLogin",
                    column: x => x.TeacherUserLogin,
                    principalTable: "Teachers",
                    principalColumn: "UserLogin",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "SubjectTeacher",
            columns: table => new
            {
                SubjectsAbbr = table.Column<string>(type: "TEXT", nullable: false),
                TeachersUserLogin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_SubjectTeacher", x => new { x.SubjectsAbbr, x.TeachersUserLogin });
                table.ForeignKey(
                    name: "FK_SubjectTeacher_Subjects_SubjectsAbbr",
                    column: x => x.SubjectsAbbr,
                    principalTable: "Subjects",
                    principalColumn: "Abbr",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_SubjectTeacher_Teachers_TeachersUserLogin",
                    column: x => x.TeachersUserLogin,
                    principalTable: "Teachers",
                    principalColumn: "UserLogin",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "ActivityEntityStudent",
            columns: table => new
            {
                ActivitiesEntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                StudentsUserLogin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ActivityEntityStudent", x => new { x.ActivitiesEntityId, x.StudentsUserLogin });
                table.ForeignKey(
                    name: "FK_ActivityEntityStudent_Activities_ActivitiesEntityId",
                    column: x => x.ActivitiesEntityId,
                    principalTable: "Activities",
                    principalColumn: "EntityId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_ActivityEntityStudent_Students_StudentsUserLogin",
                    column: x => x.StudentsUserLogin,
                    principalTable: "Students",
                    principalColumn: "UserLogin",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Evaluations",
            columns: table => new
            {
                ActivityId = table.Column<Guid>(type: "TEXT", nullable: false),
                Description = table.Column<string>(type: "TEXT", nullable: true),
                Points = table.Column<int>(type: "INTEGER", nullable: false),
                StudentId = table.Column<Guid>(type: "TEXT", nullable: false),
                ActivityEntityId = table.Column<Guid>(type: "TEXT", nullable: false),
                StudentUserLogin = table.Column<string>(type: "TEXT", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Evaluations", x => x.ActivityId);
                table.ForeignKey(
                    name: "FK_Evaluations_Activities_ActivityEntityId",
                    column: x => x.ActivityEntityId,
                    principalTable: "Activities",
                    principalColumn: "EntityId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Evaluations_Students_StudentUserLogin",
                    column: x => x.StudentUserLogin,
                    principalTable: "Students",
                    principalColumn: "UserLogin",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Activities_RoomName",
            table: "Activities",
            column: "RoomName");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_SubjectAbbr",
            table: "Activities",
            column: "SubjectAbbr");

        migrationBuilder.CreateIndex(
            name: "IX_Activities_TeacherUserLogin",
            table: "Activities",
            column: "TeacherUserLogin");

        migrationBuilder.CreateIndex(
            name: "IX_ActivityEntityStudent_StudentsUserLogin",
            table: "ActivityEntityStudent",
            column: "StudentsUserLogin");

        migrationBuilder.CreateIndex(
            name: "IX_Evaluations_ActivityEntityId",
            table: "Evaluations",
            column: "ActivityEntityId");

        migrationBuilder.CreateIndex(
            name: "IX_Evaluations_StudentUserLogin",
            table: "Evaluations",
            column: "StudentUserLogin");

        migrationBuilder.CreateIndex(
            name: "IX_PeriodicActivityDates_PeriodicActivityActivityId",
            table: "PeriodicActivityDates",
            column: "PeriodicActivityActivityId");

        migrationBuilder.CreateIndex(
            name: "IX_StudentSubject_SubjectsAbbr",
            table: "StudentSubject",
            column: "SubjectsAbbr");

        migrationBuilder.CreateIndex(
            name: "IX_SubjectTeacher_TeachersUserLogin",
            table: "SubjectTeacher",
            column: "TeachersUserLogin");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "ActivityEntityStudent");

        migrationBuilder.DropTable(
            name: "Admins");

        migrationBuilder.DropTable(
            name: "Evaluations");

        migrationBuilder.DropTable(
            name: "PeriodicActivityDates");

        migrationBuilder.DropTable(
            name: "StudentSubject");

        migrationBuilder.DropTable(
            name: "SubjectTeacher");

        migrationBuilder.DropTable(
            name: "Activities");

        migrationBuilder.DropTable(
            name: "Students");

        migrationBuilder.DropTable(
            name: "OneOffActivities");

        migrationBuilder.DropTable(
            name: "PeriodicActivities");

        migrationBuilder.DropTable(
            name: "Rooms");

        migrationBuilder.DropTable(
            name: "Subjects");

        migrationBuilder.DropTable(
            name: "Teachers");

        migrationBuilder.DropTable(
            name: "Users");
    }
}
