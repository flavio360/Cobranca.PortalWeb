using Cobranca.PortalWeb.Models.Login;
using Cobranca.PortalWeb.Models.Request.Cobranca;
using Cobranca.PortalWeb.Models.Response.Cobranca;
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

        public async Task<List<CobrancaCapaResponse>> CobrancaListaCapa(CobrancaRequest parametros)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "Listar", parametros);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CobrancaCapaResponse>>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CobrancaDetalheResponse>> CobrancaDetalhe(int id)
        {
            var response = await _client.GetAsync(BasePath + "Listar/"+ id);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CobrancaDetalheResponse>>();
            }
            else
            {
                return null;
            }
        }
    }
}
