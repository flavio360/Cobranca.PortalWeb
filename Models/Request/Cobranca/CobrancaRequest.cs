namespace Cobranca.PortalWeb.Models.Request.Cobranca
{
    public class CobrancaRequest
    {
        public int? OrigemId { get; set; }
        public int? EmpresaId { get; set; }
        public int? RamoId { get; set; }
        public string? IdExterno { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim{ get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
    }
}
