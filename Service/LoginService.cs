using Cobranca.PortalWeb.Models.Login;
using Cobranca.PortalWeb.Service.Interface;

namespace Cobranca.PortalWeb.Service
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Impacto/Login/";

        public LoginService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Add("Impacto-Api-Token", "Token");
        }

        public async Task<LoginResponseViewModel> LoginAutenticacao(LoginRequestModel loginData)
        {
            var effective = new Uri(_client.BaseAddress!, "Autenticar");
            var response = await _client.PostAsJsonAsync(BasePath + "Autenticar", loginData);

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
