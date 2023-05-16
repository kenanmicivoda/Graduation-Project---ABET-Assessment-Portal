namespace ABET_assessment_api.Helpers
{
    public class SuccesResponse
    {
        public bool Successful { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public string? Token { get; set; }
    }
}
