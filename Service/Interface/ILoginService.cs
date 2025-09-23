using Cobranca.PortalWeb.Models.Login;
using System.Threading.Tasks;

namespace Cobranca.PortalWeb.Service.Interface
{
    public interface ILoginService
    {
        Task<LoginResponseViewModel> LoginAutenticacao(LoginRequestModel loginData);
    }
}
