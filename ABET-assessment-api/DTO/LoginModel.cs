using Microsoft.Build.Framework;

namespace ABET_assessment_api.DTO
{
    public class LoginModel
    {

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
