namespace ABET_assessment_api.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<PerformanceCriteria> PerformanceCriterias { get; set; }
        public List<CourseAssessment> CourseAssessments { get; set;}
        public List<CourseLearningOutcome> CourseLearningOutcomes { get;}
    }
}
