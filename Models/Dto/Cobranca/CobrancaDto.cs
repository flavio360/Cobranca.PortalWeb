namespace Cobranca.PortalWeb.Models.Dto.Cobranca
{
    public class OrigemDto
    {
        public int EmpresaId { get; set; }
        public string TipoOrigem { get; set; } = null!;
        public string IdExterno { get; set; } = null!;
        public int? RamoId { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataEvento { get; set; }
        public string? Metadata { get; set; }

        // Coleções aninhadas
        public List<ParteDto>? Parte { get; set; }
        public List<AnexoDto>? Anexo { get; set; }
    }


    public class ParteDto
    {
        public string IdExterno { get; set; } = null!;
        public string? Tipo { get; set; }
        public string NomeRazao { get; set; } = null!;
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
    }

    public class AnexoDto
    {
        public string IdExterno { get; set; } = null!;
        public string? NomeArquivo { get; set; }
        public string? TipoDocumento { get; set; }
        public string? HashArquivo { get; set; }
        public string? Url { get; set; }
    }
}
