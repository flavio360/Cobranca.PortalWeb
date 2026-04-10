using Cobranca.PortalWeb.Domain.RenderPage;

namespace Cobranca.PortalWeb.Domain.ElementosPage
{
    public class ElementosConfiguracaoUsuario : ElementosCardBase
    {
        public List<ElementosConfiguracaoUsuario> ElementosPageConfiguracaoUsuario()
        {
            List<ElementosConfiguracaoUsuario> config = new List<ElementosConfiguracaoUsuario>();

            config.Add(new ElementosConfiguracaoUsuario
            {
                Titulo = "Listar Usuários",
                ImgPath = "/assets/icones/ListaUser.svg",
                Controller = "Usuario",
                Action = "ListaUsuario",
                CardDescricao = "Lista de Usuários"

            });

            config.Add(new ElementosConfiguracaoUsuario
            {
                Titulo = "Novo Usuário",
                ImgPath = "/assets/icones/userConfig.svg",
                Controller = "Usuario",
                Action = "ListaUsuario",
                CardDescricao = "Lista de Usuários"

            });

            return config;

        }
    }
}
