namespace ABET_assessment_api.Models
{
    public class CourseLearningOutcome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseLearningOutcomeAssessment> CourseLearningOutcomeAssessments { get; set; }
        public List<ACMIEEELearningOutcome> ACMIEEELearningOutcomes { get; set; }
        public List<StudentLearningOutcome> StudentLearningOutcomes { get; set; }
    }
}
