namespace Cobranca.PortalWeb.Models.Login
{
    public class LoginResponseViewModel
    {
        public int IdUsuario { get; set; }
        public int IdUsuarioStatus { get; set; }
        public string UsuarioStatus { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int EmpresaId { get; set; }
        public string Empresa { get; set; }
        public int IdPerfilUsuario { get; set; }
        public string DataAlteracao { get; set; }
        public string DataCriacao { get; set; }
        public bool Status { get; set; }
    }
}
