using Cobranca.PortalWeb.Models.Request.Cobranca;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Cobranca
{
    public class CobrancaController : Controller
    {

        public CobrancaController() 
        { 
        
        }

        [Route("Listar/{id}")]
        [Route("MinhasOcorrencias")]
        public async Task<IActionResult> Listar(int id, [FromQuery] CobrancaRequest filtros)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }


        [HttpPost]
        [Route("Nova/")]
        public async Task<IActionResult> Nova(int id)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }


        [HttpPut]
        [Route("Editar/")]
        public async Task<IActionResult> Editar(int id)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }


        [HttpDelete]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }
    }
}
