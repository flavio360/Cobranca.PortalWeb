using Cobranca.PortalWeb.Models.Request.Empresa;
using Cobranca.PortalWeb.Models.Response.Cobranca;
using Cobranca.PortalWeb.Models.Response.Empresa;
using Cobranca.PortalWeb.Service.Interface;

namespace Cobranca.PortalWeb.Service.Empresa
{
    public class EmpresaService : IEmpresaService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Empresa/api/VR1/empresa";

        public EmpresaService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Add("Impacto-Api-Token", "TESTE");
        }
        public async Task<bool> CreateEmpresa(CreateEmpresaRequest request)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "createEmpresa", request);

            return response.IsSuccessStatusCode;

        }

        public async Task<List<EmpresaResponse>> ReadEmpresa(ListEmpresaRequest request)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "/readImpactoEmpresas", request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<EmpresaResponse>>();
        }

        public async Task<bool> UpdateEmpresa(UpdateEmpresaRequest request)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "empresa", request);
            return response.IsSuccessStatusCode;

        }
    }
}
