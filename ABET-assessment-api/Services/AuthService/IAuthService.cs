using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;

namespace ABET_assessment_api.Services.AuthService
{
    public interface IAuthService
    {
        Task<SuccesResponse> Register(RegistrationModel registrationModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
