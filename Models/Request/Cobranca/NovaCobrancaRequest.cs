using Cobranca.PortalWeb.Models.ViewModel.Cobranca;

namespace Cobranca.PortalWeb.Models.Request.Cobranca
{
    public class NovaCobrancaRequest
    {
        // Origem / ocorrência
        public string? TipoOrigem { get; set; }            // ex.: "SINISTRO"   dropdown
        public string? IdExterno { get; set; }             // ex.: "12243271"
        public string? Titulo { get; set; }                // ex.: "Sinistro auto 00011222"
        public string? Descricao { get; set; }             // ex.: "Colisão traseira"
        public DateTime? DataEvento { get; set; }          // ex.: 2025-07-10


        // Credor (empresa)
        public string? Cnpj { get; set; }                  // ex.: "11.111.111/0001-11"
        public string? NomeCredor { get; set; }            // ex.: "Marmitas Delícia"

        // Dados financeiros da cobrança
        public decimal? ValorPrincipal { get; set; }       // ex.: 1200.50
        public DateTime? Vencimento { get; set; }          // ex.: 2025-11-10
        public decimal? DespesasTotal { get; set; }        // ex.: 150.75
        public string? CorrecaoIndice { get; set; }        // ex.: "IPCA"
        public decimal? FranquiaValor { get; set; }        // ex.: 200.00
        public DateTime? JurosDataBase { get; set; }       // ex.: 2025-11-01
        public decimal? MultaPercentual { get; set; }      // ex.: 2.50
        public decimal? NegDescontoVista { get; set; }     // ex.: 50.00
        public int? NegMaxParcelas { get; set; }           // ex.: 6
        public decimal? NegMinValorParcela { get; set; }   // ex.: 200.00
        public DateTime? NegValidade { get; set; }         // ex.: 2025-12-31
        public decimal? ValorTotalInicial { get; set; }    // ex.: 1551.25

        public List<DevedorRequest> devedorModel { get; set; } = new();
    }

    public class DevedorRequest
    {
        // Devedor (parte)

        public string? NomeDevedor { get; set; }           // ex.: "Melequinha de Jesus"
        public string? Tipo { get; set; }                  // ex.: "PF" (ou "PJ")  dropdown 
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
        public string? EndUF { get; set; }                 // ex.: "SP" dropdown
        public string? EndCEP { get; set; }                // ex.: "01311000"
    }


}
