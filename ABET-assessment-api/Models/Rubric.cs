namespace ABET_assessment_api.Models
{
    public class Rubric
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<RubricDetail> RubricDetails { get; set; }

    }
}
