using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace Cobranca.PortalWeb.Domain.RenderPage
{
    public class ElementosConfiguracao
    {
        public string Titulo {  get; set; }
        public string ImgPath {  get; set; }
        public string Controller {  get; set; }
        public string Action {  get; set; }
        public string CardDescricao {  get; set; }

        public List<ElementosConfiguracao> Configuracao()
        {
            List<ElementosConfiguracao> config = new List<ElementosConfiguracao>();

            config.Add(new ElementosConfiguracao
            {
                Titulo = "Empresa Configurações",
                ImgPath = "/assets/icones/config.png",
                Controller = "Empresa",
                Action = "ListaEmpresa",
                CardDescricao = "Configurações Empresa Impacto"

            });

            config.Add(new ElementosConfiguracao
            {
                Titulo = "Cliente Configurações",
                ImgPath = "/assets/icones/config.png",
                Controller = "Empresa",
                Action = "Home",
                CardDescricao = "Configurações Clientes Impacto"

            });



            return config;
        }
    }





}
