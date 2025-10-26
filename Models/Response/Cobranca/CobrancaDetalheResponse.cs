using Cobranca.PortalWeb.Models.ViewModel.Cobranca;

namespace Cobranca.PortalWeb.Models.Response.Cobranca
{
    public class CobrancaDetalheResponse
    {
        // Origem / ocorrência
        public string? TipoOrigem { get; set; }
        public string? IdExterno { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? CreatedAt { get; set; }

        // Devedor (parte)
        public int? ParteId { get; set; }
        public string? NomeDevedor { get; set; }
        public string? Tipo { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string? CpfCnpj { get; set; }
        public string? RG_IE { get; set; }
        public string? Tel1 { get; set; }
        public string? Tel2 { get; set; }
        public string? Email { get; set; }

        // Endereço do devedor (snapshot)
        public string? EndLogradouro { get; set; }
        public string? EndNumero { get; set; }
        public string? EndComplemento { get; set; }
        public string? EndBairro { get; set; }
        public string? EndCidade { get; set; }
        public string? EndUF { get; set; }
        public string? EndCEP { get; set; }

        // Credor (empresa)
        public string? Cnpj { get; set; }
        public string? NomeCredor { get; set; }

        // Dados financeiros da cobrança
        public decimal? ValorPrincipal { get; set; }
        public DateTime? Vencimento { get; set; }
        public int? StatusCobranca { get; set; }
        public decimal? DespesasTotal { get; set; }
        public string? CorrecaoIndice { get; set; }
        public decimal? FranquiaValor { get; set; }
        public DateTime? JurosDataBase { get; set; }
        public decimal? MultaPercentual { get; set; }
        public decimal? NegDescontoVista { get; set; }
        public int? NegMaxParcelas { get; set; }
        public decimal? NegMinValorParcela { get; set; }
        public DateTime? NegValidade { get; set; }
        public decimal? ValorTotalInicial { get; set; }

        public List<RespostaResponse> resposta { get; set; } = new();
        public List<DevedorResponse> devedor { get; set; } = new();
    }

    public class RespostaResponse
    {
        public DateTime? PaidAt { get; set; }              // NULL se ainda não pago
        public decimal? Valor { get; set; }                // valor pago (se houver)
        public string? Metodo { get; set; }                // ex.: "PIX", "BOLETO", NULL
        public string? Body { get; set; }                  // payload/resposta do gateway, se aplicável
        public string? MediaType { get; set; }             // ex.: "application/json", NULL
    }

    public class DevedorResponse
    {
        // Devedor (parte)
        public int? ParteId { get; set; }                  // ex.: 28
        public string? NomeDevedor { get; set; }           // ex.: "Melequinha de Jesus"
        public string? Tipo { get; set; }                  // ex.: "PF" (ou "PJ")
        public DateTime? DataNascimento { get; set; }      // ex.: 1988-05-12
        public string? CpfCnpj { get; set; }               // ex.: "77773111" (depende da origem)
        public string? RG_IE { get; set; }                 // ex.: "221311"
        public string? Tel1 { get; set; }                  // ex.: "+5511990000000"
        public string? Tel2 { get; set; }                  // ex.: "+5511988888888"
        public string? Email { get; set; }                 // ex.: "carlos.souza@example.com"

        // Endereço do devedor (snapshot)
        public string? EndLogradouro { get; set; }         // ex.: "Av. Paulista"
        public string? EndNumero { get; set; }             // ex.: "1000"
        public string? EndComplemento { get; set; }        // ex.: "Apto 101"
        public string? EndBairro { get; set; }             // ex.: "Bela Vista"
        public string? EndCidade { get; set; }             // ex.: "São Paulo"
        public string? EndUF { get; set; }                 // ex.: "SP"
        public string? EndCEP { get; set; }                // ex.: "01311000"
    }
}
