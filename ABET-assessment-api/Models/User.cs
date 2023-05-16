using Microsoft.AspNetCore.Identity;

namespace ABET_assessment_api.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }
    }
}
