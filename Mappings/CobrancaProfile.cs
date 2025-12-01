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
            CreateMap<CobrancaCapaResponse, CobrancaCapaView>();

            CreateMap<CobrancaDetalheResponse, CobrancaDetalheView>(); CreateMap<RespostaResponse, RespostaModel>();
            CreateMap<DevedorResponse, DevedorModel>();

            // Detalhe (mapeia listas com nomes diferentes)
            CreateMap<CobrancaDetalheResponse, CobrancaDetalheView>()
                .ForMember(d => d.respostaModel,
                           opt => opt.MapFrom(s => s.resposta ?? new List<RespostaResponse>()))
                .ForMember(d => d.devedorModel,
                           opt => opt.MapFrom(s => s.devedor ?? new List<DevedorResponse>()));
        }
    }
}
