using Cobranca.PortalWeb.Models.Request.Empresa;
using Cobranca.PortalWeb.Models.Response.Empresa;
using Cobranca.PortalWeb.Models.ViewModel.Common;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Cobranca.PortalWeb.Controllers.Empresa
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        [Route("NovaEmpresa")]
        public async Task<IActionResult> NovaEmpresa([FromForm] CreateEmpresaRequest request)
        {

            var result = await _empresaService.CreateEmpresa(request);

            if (result)
            {
                return Json(new
                {
                    sucesso = true,
                    mensagem = "Empresa cadastrada com sucesso.",
                    route = Url.Action("ListaEmpresa", "Empresa")
                });
            }

            return Json(new
            {
                sucesso = false,
                mensagem = "Erro ao cadastrar empresa.",
                route = Url.Action("ListaEmpresa", "Empresa")
            });

        }

        [HttpGet]
        [Route("ListaEmpresa")]
        public async Task<IActionResult> ListaEmpresa()
        {
            var empresa = new ListEmpresaRequest();

            var view = await _empresaService.ReadEmpresa(empresa);

            return View(view);
        }




    }
}
