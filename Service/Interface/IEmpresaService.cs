using Cobranca.PortalWeb.Models.Request.Empresa;
using Cobranca.PortalWeb.Models.Response.Empresa;

namespace Cobranca.PortalWeb.Service.Interface
{
    public interface IEmpresaService
    {
        Task<bool> CreateEmpresa(CreateEmpresaRequest request);
        Task<List<EmpresaResponse>> ReadEmpresa(ListEmpresaRequest request);
        Task<bool> UpdateEmpresa(UpdateEmpresaRequest request);
    }
}
