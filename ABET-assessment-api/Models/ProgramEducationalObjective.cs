namespace ABET_assessment_api.Models
{
    public class ProgramEducationalObjective
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<StudentLearningOutcome> StudentLearningOutcomes { get; set; }
    }
}
