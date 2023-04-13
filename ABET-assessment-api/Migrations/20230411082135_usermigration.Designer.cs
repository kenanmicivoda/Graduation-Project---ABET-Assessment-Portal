﻿// <auto-generated />
using System;
using ABET_assessment_api.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ABET_assessment_api.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230411082135_usermigration")]
    partial class usermigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ABET_assessment_api.Models.ACMIEEELearningOutcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ACMIEEELearningOutcomes");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Assessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssessmentMethodId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentLearningOutcomeAssessmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentMethodId");

                    b.HasIndex("StudentLearningOutcomeAssessmentId");

                    b.ToTable("Assessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.AssessmentMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("AssessmentsMethods");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.AssessmentScore", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AssessmentId")
                        .HasColumnType("int");

                    b.Property<int?>("RubricDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssessmentId");

                    b.HasIndex("RubricDetailId");

                    b.ToTable("AssessmentsScores");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseLearningOutcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CoursesLearningOutcomes");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseLearningOutcomeAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseAssessmentId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseLearningOutcomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseAssessmentId");

                    b.HasIndex("CourseLearningOutcomeId");

                    b.ToTable("CourseLearningOutcomeAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.PerformanceCriteria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentLearningOutcomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentLearningOutcomeId");

                    b.ToTable("PerformanceCriterias");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.ProgramEducationalObjective", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProgramEducationalObjectives");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Rubric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentLearningOutcomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentLearningOutcomeId");

                    b.ToTable("Rubrics");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.RubricDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PerformanceCriteriaId")
                        .HasColumnType("int");

                    b.Property<int?>("RubricId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceCriteriaId");

                    b.HasIndex("RubricId");

                    b.ToTable("RubricDetails");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.StudentLearningOutcome", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudentLearningOutcomes");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.StudentLearningOutcomeAssessment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentLearningOutcomeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentLearningOutcomeId");

                    b.ToTable("StudentLearningOutcomeAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ACMIEEELearningOutcomeCourseLearningOutcome", b =>
                {
                    b.Property<int>("ACMIEEELearningOutcomesId")
                        .HasColumnType("int");

                    b.Property<int>("courseLearningOutcomesId")
                        .HasColumnType("int");

                    b.HasKey("ACMIEEELearningOutcomesId", "courseLearningOutcomesId");

                    b.HasIndex("courseLearningOutcomesId");

                    b.ToTable("ACMIEEELearningOutcomeCourseLearningOutcome");
                });

            modelBuilder.Entity("CourseLearningOutcomeStudentLearningOutcome", b =>
                {
                    b.Property<int>("CourseLearningOutcomesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentLearningOutcomesId")
                        .HasColumnType("int");

                    b.HasKey("CourseLearningOutcomesId", "StudentLearningOutcomesId");

                    b.HasIndex("StudentLearningOutcomesId");

                    b.ToTable("CourseLearningOutcomeStudentLearningOutcome");
                });

            modelBuilder.Entity("ProgramEducationalObjectiveStudentLearningOutcome", b =>
                {
                    b.Property<int>("ProgramEducationalObjectivesId")
                        .HasColumnType("int");

                    b.Property<int>("StudentLearningOutcomesId")
                        .HasColumnType("int");

                    b.HasKey("ProgramEducationalObjectivesId", "StudentLearningOutcomesId");

                    b.HasIndex("StudentLearningOutcomesId");

                    b.ToTable("ProgramEducationalObjectiveStudentLearningOutcome");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Assessment", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.AssessmentMethod", null)
                        .WithMany("Assessments")
                        .HasForeignKey("AssessmentMethodId");

                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcomeAssessment", null)
                        .WithMany("Assessments")
                        .HasForeignKey("StudentLearningOutcomeAssessmentId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.AssessmentScore", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.Assessment", null)
                        .WithMany("Assessments")
                        .HasForeignKey("AssessmentId");

                    b.HasOne("ABET_assessment_api.Models.RubricDetail", null)
                        .WithMany("AssessmentScores")
                        .HasForeignKey("RubricDetailId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseAssessment", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.Course", null)
                        .WithMany("CourseAssessments")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseLearningOutcome", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.Course", null)
                        .WithMany("CourseLearningOutcomes")
                        .HasForeignKey("CourseId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseLearningOutcomeAssessment", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.CourseAssessment", null)
                        .WithMany("CourseLearningOutcomeAssessments")
                        .HasForeignKey("CourseAssessmentId");

                    b.HasOne("ABET_assessment_api.Models.CourseLearningOutcome", null)
                        .WithMany("CourseLearningOutcomeAssessments")
                        .HasForeignKey("CourseLearningOutcomeId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.PerformanceCriteria", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.Course", null)
                        .WithMany("PerformanceCriterias")
                        .HasForeignKey("CourseId");

                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcome", null)
                        .WithMany("PerformanceCriterias")
                        .HasForeignKey("StudentLearningOutcomeId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Rubric", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcome", null)
                        .WithMany("Rubrics")
                        .HasForeignKey("StudentLearningOutcomeId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.RubricDetail", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.PerformanceCriteria", null)
                        .WithMany("RubricDetails")
                        .HasForeignKey("PerformanceCriteriaId");

                    b.HasOne("ABET_assessment_api.Models.Rubric", null)
                        .WithMany("RubricDetails")
                        .HasForeignKey("RubricId");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.StudentLearningOutcomeAssessment", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcome", null)
                        .WithMany("StudentLearningOutcomeAssessments")
                        .HasForeignKey("StudentLearningOutcomeId");
                });

            modelBuilder.Entity("ACMIEEELearningOutcomeCourseLearningOutcome", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.ACMIEEELearningOutcome", null)
                        .WithMany()
                        .HasForeignKey("ACMIEEELearningOutcomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABET_assessment_api.Models.CourseLearningOutcome", null)
                        .WithMany()
                        .HasForeignKey("courseLearningOutcomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseLearningOutcomeStudentLearningOutcome", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.CourseLearningOutcome", null)
                        .WithMany()
                        .HasForeignKey("CourseLearningOutcomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcome", null)
                        .WithMany()
                        .HasForeignKey("StudentLearningOutcomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProgramEducationalObjectiveStudentLearningOutcome", b =>
                {
                    b.HasOne("ABET_assessment_api.Models.ProgramEducationalObjective", null)
                        .WithMany()
                        .HasForeignKey("ProgramEducationalObjectivesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ABET_assessment_api.Models.StudentLearningOutcome", null)
                        .WithMany()
                        .HasForeignKey("StudentLearningOutcomesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Assessment", b =>
                {
                    b.Navigation("Assessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.AssessmentMethod", b =>
                {
                    b.Navigation("Assessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Course", b =>
                {
                    b.Navigation("CourseAssessments");

                    b.Navigation("CourseLearningOutcomes");

                    b.Navigation("PerformanceCriterias");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseAssessment", b =>
                {
                    b.Navigation("CourseLearningOutcomeAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.CourseLearningOutcome", b =>
                {
                    b.Navigation("CourseLearningOutcomeAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.PerformanceCriteria", b =>
                {
                    b.Navigation("RubricDetails");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.Rubric", b =>
                {
                    b.Navigation("RubricDetails");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.RubricDetail", b =>
                {
                    b.Navigation("AssessmentScores");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.StudentLearningOutcome", b =>
                {
                    b.Navigation("PerformanceCriterias");

                    b.Navigation("Rubrics");

                    b.Navigation("StudentLearningOutcomeAssessments");
                });

            modelBuilder.Entity("ABET_assessment_api.Models.StudentLearningOutcomeAssessment", b =>
                {
                    b.Navigation("Assessments");
                });
#pragma warning restore 612, 618
        }
    }
}
