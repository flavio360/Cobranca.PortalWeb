using Cobranca.PortalWeb.Domain.RenderPage;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Sistema
{
    public class ConfiguracaoController : Controller
    {

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var _view = new ElementosConfiguracao().Configuracao();
            return View(_view);
        }
    }
}
