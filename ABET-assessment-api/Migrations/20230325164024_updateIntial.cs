using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABET_assessment_api.Migrations
{
    /// <inheritdoc />
    public partial class updateIntial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentsMethods_AssessmentsMethods_AssessmentMethodId",
                table: "AssessmentsMethods");

            migrationBuilder.DropIndex(
                name: "IX_AssessmentsMethods_AssessmentMethodId",
                table: "AssessmentsMethods");

            migrationBuilder.DropColumn(
                name: "AssessmentMethodId",
                table: "AssessmentsMethods");

            migrationBuilder.AddColumn<int>(
                name: "AssessmentMethodId",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentLearningOutcomeAssessmentId",
                table: "Assessments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_AssessmentMethodId",
                table: "Assessments",
                column: "AssessmentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Assessments_StudentLearningOutcomeAssessmentId",
                table: "Assessments",
                column: "StudentLearningOutcomeAssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_AssessmentsMethods_AssessmentMethodId",
                table: "Assessments",
                column: "AssessmentMethodId",
                principalTable: "AssessmentsMethods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assessments_StudentLearningOutcomeAssessments_StudentLearningOutcomeAssessmentId",
                table: "Assessments",
                column: "StudentLearningOutcomeAssessmentId",
                principalTable: "StudentLearningOutcomeAssessments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_AssessmentsMethods_AssessmentMethodId",
                table: "Assessments");

            migrationBuilder.DropForeignKey(
                name: "FK_Assessments_StudentLearningOutcomeAssessments_StudentLearningOutcomeAssessmentId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_AssessmentMethodId",
                table: "Assessments");

            migrationBuilder.DropIndex(
                name: "IX_Assessments_StudentLearningOutcomeAssessmentId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "AssessmentMethodId",
                table: "Assessments");

            migrationBuilder.DropColumn(
                name: "StudentLearningOutcomeAssessmentId",
                table: "Assessments");

            migrationBuilder.AddColumn<int>(
                name: "AssessmentMethodId",
                table: "AssessmentsMethods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentsMethods_AssessmentMethodId",
                table: "AssessmentsMethods",
                column: "AssessmentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentsMethods_AssessmentsMethods_AssessmentMethodId",
                table: "AssessmentsMethods",
                column: "AssessmentMethodId",
                principalTable: "AssessmentsMethods",
                principalColumn: "Id");
        }
    }
}
