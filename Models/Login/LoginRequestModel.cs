namespace Cobranca.PortalWeb.Models.Login
{
    public class LoginRequestModel
    {
        public string Senha { get; set; }
        public string Email { get; set; }
    }

    public class LoginResponseModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string Senha { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool Status { get; set; }
    }
}
