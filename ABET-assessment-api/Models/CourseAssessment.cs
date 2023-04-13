namespace ABET_assessment_api.Models
{
    public class CourseAssessment
    {
        public int Id { get; set; }
        public List<CourseLearningOutcomeAssessment> CourseLearningOutcomeAssessments { get;}
    }
}
