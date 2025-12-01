using Cobranca.PortalWeb.Models.Request.Cobranca;

namespace Cobranca.PortalWeb.Models.ViewModel.Cobranca
{
    public class CobrancaImportacaoView
    {
        public bool Erro { get; set; } = true;
        public string Mensagem { get; set; }
        public string NomeDevedor { get; set; }
        public string CodigoInterno { get; set; }
        public decimal ValorSinistro { get; set; }
        public decimal ValorMulta { get; set; }
        public DateTime DataSinistro { get; set; }

    }






}
