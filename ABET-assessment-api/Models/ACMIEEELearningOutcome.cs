namespace ABET_assessment_api.Models
{
    public class ACMIEEELearningOutcome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CourseLearningOutcome> courseLearningOutcomes { get; set; }
    }
}
