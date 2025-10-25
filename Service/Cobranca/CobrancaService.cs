using Cobranca.PortalWeb.Service.Interface;

namespace Cobranca.PortalWeb.Service.Cobranca
{
    public class CobrancaService : ICobrancaService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Impacto/Cobranca/";

        public CobrancaService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Add("Impacto-Api-Token", "Token");
        }
    }
}
