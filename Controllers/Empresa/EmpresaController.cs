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
        [Route("UpdateEmpresa")]
        public async Task<IActionResult> UpdateEmpresa([FromForm] UpdateEmpresaRequest request)
        {

            var result = await _empresaService.UpdateEmpresa(request);

            if (result)
            {
                return Json(new
                {
                    sucesso = true,
                    mensagem = "Empresa atualizada com sucesso.",
                    route = Url.Action("ListaEmpresa", "Empresa")
                });
            }

            return Json(new
            {
                sucesso = false,
                mensagem = "Erro ao atualizar a empresa.",
                route = Url.Action("ListaEmpresa", "Empresa")
            });

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

        [HttpDelete]
        [Route("DeleteEmpresa/{empresaId}")]
        public async Task<IActionResult> DeleteEmpresa(int empresaId)
        {

            return View();
        }




    }
}
