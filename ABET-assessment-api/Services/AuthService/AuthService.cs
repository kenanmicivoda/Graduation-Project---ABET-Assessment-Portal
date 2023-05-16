using ABET_assessment_api.DTO;
using ABET_assessment_api.Helpers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;


namespace ABET_assessment_api.Services.AuthService
{
    public class AuthService : IAuthService {

        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<SuccesResponse> Register(RegistrationModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync("api/accounts", registerModel);
            if (!result.IsSuccessStatusCode)
                return new SuccesResponse { Successful = false, Errors = new List<string> { "Error occured" } };
            return new SuccesResponse { Successful = true, Errors = new List<string> { "Account Created successfully" } };
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            var loginAsJson = JsonSerializer.Serialize(loginModel);
            var response = await _httpClient.PostAsync("api/Login",
                new StringContent(loginAsJson, Encoding.UTF8, "application/json"));

            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult!;
            }

            await _localStorage.SetItemAsync("authToken", loginResult!.Token);
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.Token!);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
