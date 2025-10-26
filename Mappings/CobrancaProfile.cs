using AutoMapper;
using Cobranca.PortalWeb.Models.Response.Cobranca;
using Cobranca.PortalWeb.Models.ViewModel.Cobranca;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Cobranca.PortalWeb.Mappings
{
    public class CobrancaProfile : Profile
    {
        public CobrancaProfile()
        {
            CreateMap<CobrancaCapaResponse, CobrancaCapaViewModel>();

            CreateMap<CobrancaDetalheResponse, CobrancaDetalheViewModel>();

        }
    }
}
