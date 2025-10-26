using Cobranca.PortalWeb.Models.Request.Cobranca;
using Cobranca.PortalWeb.Models.Response.Cobranca;

namespace Cobranca.PortalWeb.Service.Interface
{
    public interface ICobrancaService
    {
        Task<List<CobrancaCapaResponse>> CobrancaListaCapa(CobrancaRequest parametros);
        Task<List<CobrancaDetalheResponse>> CobrancaDetalhe(int id);
    }
}
