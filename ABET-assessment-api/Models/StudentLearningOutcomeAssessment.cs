namespace ABET_assessment_api.Models
{
    public class StudentLearningOutcomeAssessment
    {
        public int Id { get; set; }
        public string Score { get; set; }
        public List<Assessment> Assessments { get; set; }
    }
}
