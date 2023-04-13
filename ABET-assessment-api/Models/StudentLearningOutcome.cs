namespace ABET_assessment_api.Models
{
    public class StudentLearningOutcome
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Rubric> Rubrics { get; set; }
        public List<CourseLearningOutcome> CourseLearningOutcomes { get; set; }
        public List<PerformanceCriteria> PerformanceCriterias { get; set; }
        public List<StudentLearningOutcomeAssessment> StudentLearningOutcomeAssessments { get; set; }
        public List<ProgramEducationalObjective> ProgramEducationalObjectives { get; set; }

    }
}
