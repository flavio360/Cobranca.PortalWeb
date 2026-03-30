using Cobranca.PortalWeb.Models.Common;

namespace Cobranca.PortalWeb.Models.Request.Cobranca
{
    public class OrigemRequest
    {
        public int EmpresaId { get; set; }
        public string TipoOrigem { get; set; }
        public string IdExterno { get; set; }
        public int? RamoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataEvento { get; set; }
        public object Metadata { get; set; } = new { };
        public string? Tipo { get; set; }
        public string? NomeRazao { get; set; }
        public string? CpfCnpj { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? RG_IE { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? Email { get; set; }
        public string? EndLogradouro { get; set; }
        public string? EndNumero { get; set; }
        public string? EndComplemento { get; set; }
        public string? EndBairro { get; set; }
        public string? EndCidade { get; set; }
        public string? EndUF { get; set; }
        public string? EndCEP { get; set; }
        public List<AnexoRequest>? Anexo { get; set; }
    }
}
