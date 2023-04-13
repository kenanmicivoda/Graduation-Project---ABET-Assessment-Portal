namespace ABET_assessment_api.Models
{
    public class RubricDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<AssessmentScore> AssessmentScores { get; set; }

    }
}
