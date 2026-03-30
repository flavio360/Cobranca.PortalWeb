namespace Cobranca.PortalWeb.Models.Response.Empresa
{
    public class EmpresaResponse
    {
        public int ImpactoEmpresaCadastroId { get; set; }

        public string EmpresaNome { get; set; } = null!;

        public string? EmpresaNomeFantasia { get; set; }

        public string EmpresaCNPJ { get; set; } = null!;

        public string? IE { get; set; }

        public string? IM { get; set; }

        public string? CEP { get; set; }

        public string? Logradouro { get; set; }

        public string? Numero { get; set; }

        public string? Complemento { get; set; }

        public string? Bairro { get; set; }

        public string? Cidade { get; set; }

        public string? Estado { get; set; } // char(2)

        public string? Telefone { get; set; }

        public string? Email { get; set; }

        public string? Site { get; set; }

        public string? CNAE { get; set; }

        public bool? Ativo { get; set; }

        public DateTime? DataCadastro { get; set; }
    }
}
