using Cobranca.PortalWeb.Domain.ElementosPage;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace Cobranca.PortalWeb.Domain.RenderPage
{
    public class ElementosConfiguracao : ElementosCardBase
    {

        public List<ElementosConfiguracao> Configuracao()
        {
            List<ElementosConfiguracao> config = new List<ElementosConfiguracao>();

            config.Add(new ElementosConfiguracao
            {
                Titulo = "Empresa Configurações",
                ImgPath = "/assets/icones/config.svg",
                Controller = "Empresa",
                Action = "ListaEmpresa",
                CardDescricao = "Configurações Empresa Impacto"

            });

            config.Add(new ElementosConfiguracao
            {
                Titulo = "Cliente Configurações",
                ImgPath = "/assets/icones/config.svg",
                Controller = "Empresa",
                Action = "Home",
                CardDescricao = "Configurações Clientes Impacto"

            });

            config.Add(new ElementosConfiguracao
            {
                Titulo = "Usuários Configurações",
                ImgPath = "/assets/icones/users.svg",
                Controller = "Usuario",
                Action = "Home",
                CardDescricao = "Configurações de Usuários Impacto"

            });



            return config;
        }
    }





}
