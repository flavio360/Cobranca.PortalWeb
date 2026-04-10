using Cobranca.PortalWeb.Domain.ElementosPage;
using Cobranca.PortalWeb.Domain.RenderPage;
using Cobranca.PortalWeb.Models.Request.Empresa;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Usuario
{
    public class UsuarioController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var _view = new ElementosConfiguracaoUsuario().ElementosPageConfiguracaoUsuario();
            return View(_view);
        }
    }
}
