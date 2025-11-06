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

            CreateMap<CobrancaDetalheResponse, CobrancaDetalheViewModel>(); CreateMap<RespostaResponse, RespostaModel>();
            CreateMap<DevedorResponse, DevedorModel>();

            // Detalhe (mapeia listas com nomes diferentes)
            CreateMap<CobrancaDetalheResponse, CobrancaDetalheViewModel>()
                .ForMember(d => d.respostaModel,
                           opt => opt.MapFrom(s => s.resposta ?? new List<RespostaResponse>()))
                .ForMember(d => d.devedorModel,
                           opt => opt.MapFrom(s => s.devedor ?? new List<DevedorResponse>()));
        }
    }
}
