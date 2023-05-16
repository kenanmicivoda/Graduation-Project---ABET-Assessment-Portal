using ABET_assessment_api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ABET_assessment_api.DataContext
{
    public class Context : IdentityDbContext
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<ACMIEEELearningOutcome> ACMIEEELearningOutcomes { get; set; }
        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<AssessmentMethod> AssessmentsMethods { get; set;}
        public DbSet<AssessmentScore> AssessmentsScores { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseAssessment> CoursesAssessments { get; set;}
        public DbSet<CourseLearningOutcome> CoursesLearningOutcomes { get; set; }
        public DbSet<CourseLearningOutcomeAssessment> CourseLearningOutcomeAssessments { get; set; }
        public DbSet<PerformanceCriteria> PerformanceCriterias { get; set; }
        public DbSet<ProgramEducationalObjective> ProgramEducationalObjectives { get; set; }
        public DbSet<Rubric> Rubrics { get; set; }
        public DbSet<RubricDetail> RubricDetails { get; set; }  
        public DbSet<StudentLearningOutcome> StudentLearningOutcomes { get;set; }
        public DbSet<StudentLearningOutcomeAssessment> StudentLearningOutcomeAssessments { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
