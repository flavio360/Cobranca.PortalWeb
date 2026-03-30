using Cobranca.PortalWeb.Models.Request.Empresa;
using Cobranca.PortalWeb.Models.Response.Empresa;
using Cobranca.PortalWeb.Models.ViewModel.Common;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Empresa
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpGet]
        [Route("ListaEmpresa")]
        public async Task<IActionResult> ListaEmpresa()
        {
            var empresa = new ListEmpresaRequest();

            var view = await _empresaService.ReadEmpresa(empresa);

            return View(view);
        }

        [HttpGet]
        [Route("NovaEmpresa")]
        public async Task<IActionResult> NovaEmpresa([FromForm] CreateEmpresaRequest request)
        {

            return View();
        }


    }
}
