using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABET_assessment_api.Migrations
{
    /// <inheritdoc />
    public partial class IntialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACMIEEELearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACMIEEELearningOutcomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssessmentsMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssessmentMethodId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentsMethods_AssessmentsMethods_AssessmentMethodId",
                        column: x => x.AssessmentMethodId,
                        principalTable: "AssessmentsMethods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgramEducationalObjectives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramEducationalObjectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentLearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLearningOutcomes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesAssessments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CoursesLearningOutcomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesLearningOutcomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesLearningOutcomes_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PerformanceCriterias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: true),
                    StudentLearningOutcomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformanceCriterias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PerformanceCriterias_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PerformanceCriterias_StudentLearningOutcomes_StudentLearningOutcomeId",
                        column: x => x.StudentLearningOutcomeId,
                        principalTable: "StudentLearningOutcomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProgramEducationalObjectiveStudentLearningOutcome",
                columns: table => new
                {
                    ProgramEducationalObjectivesId = table.Column<int>(type: "int", nullable: false),
                    StudentLearningOutcomesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramEducationalObjectiveStudentLearningOutcome", x => new { x.ProgramEducationalObjectivesId, x.StudentLearningOutcomesId });
                    table.ForeignKey(
                        name: "FK_ProgramEducationalObjectiveStudentLearningOutcome_ProgramEducationalObjectives_ProgramEducationalObjectivesId",
                        column: x => x.ProgramEducationalObjectivesId,
                        principalTable: "ProgramEducationalObjectives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProgramEducationalObjectiveStudentLearningOutcome_StudentLearningOutcomes_StudentLearningOutcomesId",
                        column: x => x.StudentLearningOutcomesId,
                        principalTable: "StudentLearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rubrics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentLearningOutcomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rubrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rubrics_StudentLearningOutcomes_StudentLearningOutcomeId",
                        column: x => x.StudentLearningOutcomeId,
                        principalTable: "StudentLearningOutcomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentLearningOutcomeAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentLearningOutcomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLearningOutcomeAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentLearningOutcomeAssessments_StudentLearningOutcomes_StudentLearningOutcomeId",
                        column: x => x.StudentLearningOutcomeId,
                        principalTable: "StudentLearningOutcomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ACMIEEELearningOutcomeCourseLearningOutcome",
                columns: table => new
                {
                    ACMIEEELearningOutcomesId = table.Column<int>(type: "int", nullable: false),
                    courseLearningOutcomesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACMIEEELearningOutcomeCourseLearningOutcome", x => new { x.ACMIEEELearningOutcomesId, x.courseLearningOutcomesId });
                    table.ForeignKey(
                        name: "FK_ACMIEEELearningOutcomeCourseLearningOutcome_ACMIEEELearningOutcomes_ACMIEEELearningOutcomesId",
                        column: x => x.ACMIEEELearningOutcomesId,
                        principalTable: "ACMIEEELearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ACMIEEELearningOutcomeCourseLearningOutcome_CoursesLearningOutcomes_courseLearningOutcomesId",
                        column: x => x.courseLearningOutcomesId,
                        principalTable: "CoursesLearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseLearningOutcomeAssessments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseAssessmentId = table.Column<int>(type: "int", nullable: true),
                    CourseLearningOutcomeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearningOutcomeAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseLearningOutcomeAssessments_CoursesAssessments_CourseAssessmentId",
                        column: x => x.CourseAssessmentId,
                        principalTable: "CoursesAssessments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseLearningOutcomeAssessments_CoursesLearningOutcomes_CourseLearningOutcomeId",
                        column: x => x.CourseLearningOutcomeId,
                        principalTable: "CoursesLearningOutcomes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseLearningOutcomeStudentLearningOutcome",
                columns: table => new
                {
                    CourseLearningOutcomesId = table.Column<int>(type: "int", nullable: false),
                    StudentLearningOutcomesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLearningOutcomeStudentLearningOutcome", x => new { x.CourseLearningOutcomesId, x.StudentLearningOutcomesId });
                    table.ForeignKey(
                        name: "FK_CourseLearningOutcomeStudentLearningOutcome_CoursesLearningOutcomes_CourseLearningOutcomesId",
                        column: x => x.CourseLearningOutcomesId,
                        principalTable: "CoursesLearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseLearningOutcomeStudentLearningOutcome_StudentLearningOutcomes_StudentLearningOutcomesId",
                        column: x => x.StudentLearningOutcomesId,
                        principalTable: "StudentLearningOutcomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RubricDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformanceCriteriaId = table.Column<int>(type: "int", nullable: true),
                    RubricId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RubricDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RubricDetails_PerformanceCriterias_PerformanceCriteriaId",
                        column: x => x.PerformanceCriteriaId,
                        principalTable: "PerformanceCriterias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RubricDetails_Rubrics_RubricId",
                        column: x => x.RubricId,
                        principalTable: "Rubrics",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AssessmentsScores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Score = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssessmentId = table.Column<int>(type: "int", nullable: true),
                    RubricDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentsScores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentsScores_Assessments_AssessmentId",
                        column: x => x.AssessmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AssessmentsScores_RubricDetails_RubricDetailId",
                        column: x => x.RubricDetailId,
                        principalTable: "RubricDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ACMIEEELearningOutcomeCourseLearningOutcome_courseLearningOutcomesId",
                table: "ACMIEEELearningOutcomeCourseLearningOutcome",
                column: "courseLearningOutcomesId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentsMethods_AssessmentMethodId",
                table: "AssessmentsMethods",
                column: "AssessmentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentsScores_AssessmentId",
                table: "AssessmentsScores",
                column: "AssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentsScores_RubricDetailId",
                table: "AssessmentsScores",
                column: "RubricDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearningOutcomeAssessments_CourseAssessmentId",
                table: "CourseLearningOutcomeAssessments",
                column: "CourseAssessmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearningOutcomeAssessments_CourseLearningOutcomeId",
                table: "CourseLearningOutcomeAssessments",
                column: "CourseLearningOutcomeId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseLearningOutcomeStudentLearningOutcome_StudentLearningOutcomesId",
                table: "CourseLearningOutcomeStudentLearningOutcome",
                column: "StudentLearningOutcomesId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesAssessments_CourseId",
                table: "CoursesAssessments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesLearningOutcomes_CourseId",
                table: "CoursesLearningOutcomes",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceCriterias_CourseId",
                table: "PerformanceCriterias",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceCriterias_StudentLearningOutcomeId",
                table: "PerformanceCriterias",
                column: "StudentLearningOutcomeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramEducationalObjectiveStudentLearningOutcome_StudentLearningOutcomesId",
                table: "ProgramEducationalObjectiveStudentLearningOutcome",
                column: "StudentLearningOutcomesId");

            migrationBuilder.CreateIndex(
                name: "IX_RubricDetails_PerformanceCriteriaId",
                table: "RubricDetails",
                column: "PerformanceCriteriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RubricDetails_RubricId",
                table: "RubricDetails",
                column: "RubricId");

            migrationBuilder.CreateIndex(
                name: "IX_Rubrics_StudentLearningOutcomeId",
                table: "Rubrics",
                column: "StudentLearningOutcomeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLearningOutcomeAssessments_StudentLearningOutcomeId",
                table: "StudentLearningOutcomeAssessments",
                column: "StudentLearningOutcomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACMIEEELearningOutcomeCourseLearningOutcome");

            migrationBuilder.DropTable(
                name: "AssessmentsMethods");

            migrationBuilder.DropTable(
                name: "AssessmentsScores");

            migrationBuilder.DropTable(
                name: "CourseLearningOutcomeAssessments");

            migrationBuilder.DropTable(
                name: "CourseLearningOutcomeStudentLearningOutcome");

            migrationBuilder.DropTable(
                name: "ProgramEducationalObjectiveStudentLearningOutcome");

            migrationBuilder.DropTable(
                name: "StudentLearningOutcomeAssessments");

            migrationBuilder.DropTable(
                name: "ACMIEEELearningOutcomes");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "RubricDetails");

            migrationBuilder.DropTable(
                name: "CoursesAssessments");

            migrationBuilder.DropTable(
                name: "CoursesLearningOutcomes");

            migrationBuilder.DropTable(
                name: "ProgramEducationalObjectives");

            migrationBuilder.DropTable(
                name: "PerformanceCriterias");

            migrationBuilder.DropTable(
                name: "Rubrics");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "StudentLearningOutcomes");
        }
    }
}
