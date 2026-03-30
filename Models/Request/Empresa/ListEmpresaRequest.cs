using Cobranca.PortalWeb.Models.Request.Common;

namespace Cobranca.PortalWeb.Models.Request.Empresa
{
    public class ListEmpresaRequest: BaseRequest
    {
        public int? ImpactoEmpresaCadastroId { get; set; } = 0;
        public string? EmpresaCNPJ { get; set; } = string.Empty;
    }
}
