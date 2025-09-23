using Cobranca.PortalWeb.Models.Login;
using Cobranca.PortalWeb.Service.Interface;

namespace Cobranca.PortalWeb.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Security/";

        public LoginService(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<LoginResponseViewModel> LoginAutenticacao(LoginRequestModel loginData)
        {
            var response = await _client.PostAsJsonAsync("login/authenticate", loginData);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LoginResponseViewModel>();
            }
            else
            {
                return null;
            }
        }
    }
}
