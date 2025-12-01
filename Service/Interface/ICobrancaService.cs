using Cobranca.PortalWeb.Models.Request.Cobranca;
using Cobranca.PortalWeb.Models.Response.Cobranca;
using Cobranca.PortalWeb.Models.ViewModel.Cobranca;

namespace Cobranca.PortalWeb.Service.Interface
{
    public interface ICobrancaService
    {
        Task<List<CobrancaCapaResponse>> CobrancaListaCapa(CobrancaRequest parametros);
        Task<List<CobrancaDetalheResponse>> CobrancaDetalhe(int id);




        #region  Validação (Depois levar para outra classe service)
        CobrancaImportacaoView ValidaExcel(IFormFile file);

        #endregion

    }
}
