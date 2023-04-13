namespace ABET_assessment_api.Models
{
    public class Assessment
    {
        public int Id { get; set; }
        public List<AssessmentScore> Assessments { get;set; }
    }
}
