namespace Cobranca.PortalWeb.Models.ViewModel.Cobranca
{
    public class CobrancaCapaViewModel
    {
        public int OrigemId { get; set; }
        public int EmpresaId { get; set; }
        public int StatusId { get; set; }
        public string? StatusNome { get; set; }
        public string? NomeCredor { get; set; }
        public string? NomeDevedor { get; set; }
        public string? IdExterno { get; set; }
        public string? Titulo { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? CreatedAt { get; set; }


        public string DataEventoFormatada =>
            DataEvento?.ToString("dd/MM/yyyy") ?? string.Empty;

        public string CreatedAtFormatada =>
            CreatedAt?.ToString("dd/MM/yyyy HH:mm") ?? string.Empty;
    }



}
