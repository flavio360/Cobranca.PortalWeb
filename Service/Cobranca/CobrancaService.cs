using Cobranca.PortalWeb.Models.Dto.Cobranca;
using Cobranca.PortalWeb.Models.Login;
using Cobranca.PortalWeb.Models.Request.Cobranca;
using Cobranca.PortalWeb.Models.Response.Cobranca;
using Cobranca.PortalWeb.Models.ViewModel.Cobranca;
using Cobranca.PortalWeb.Service.Interface;
using OfficeOpenXml;
using System.Globalization;


namespace Cobranca.PortalWeb.Service.Cobranca
{
    public class CobrancaService : ICobrancaService
    {
        private readonly HttpClient _client;
        public const string BasePath = "api/Impacto/Cobranca/";

        public CobrancaService(HttpClient httpClient)
        {
            _client = httpClient;
            _client.DefaultRequestHeaders.Add("Impacto-Api-Token", "Token");
        }

        public async Task<List<CobrancaCapaResponse>> CobrancaListaCapa(CobrancaRequest parametros)
        {
            var response = await _client.PostAsJsonAsync(BasePath + "Listar", parametros);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CobrancaCapaResponse>>();
            }
            else
            {
                return null;
            }
        }

        public async Task<List<CobrancaDetalheResponse>> CobrancaDetalhe(int id)
        {
            var response = await _client.GetAsync(BasePath + "Listar/"+ id);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<CobrancaDetalheResponse>>();
            }
            else
            {
                return null;
            }
        }

        public CobrancaImportacaoDto ValidaExcel(IFormFile file)
        {
            var arquivo = new CobrancaImportacaoDto();

            if (file.Headers.Count < 1)
            {
                arquivo.Mensagem = "Não encontramos registros para importação!";
            }





            try
            {
                using (var stream = new MemoryStream())
                {
                    file.CopyTo(stream);

                    using (var package = new ExcelPackage(stream))
                    {
                        var worksheet = package.Workbook.Worksheets.First();

                        int rowCount = worksheet.Dimension.Rows;
                        int colCount = worksheet.Dimension.Columns;

                        var colMap = new Dictionary<string, int>();
                        for (int col = 1; col <= colCount; col++)
                        {
                            var header = worksheet.Cells[1, col].Text.Trim();
                            if (!string.IsNullOrEmpty(header))
                                colMap[header] = col;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }




            return arquivo;
        }



        //private List<OrigemRequest> ConvertParaObjetoNovaCobranca(IFormFile file)
        //{
        //    var cobrancas = new List<CobrancaImportacaoDto>();

        //    using (var stream = new MemoryStream())
        //    {
        //        file.CopyTo(stream);
        //        using (var package = new ExcelPackage(stream))
        //        {
        //            var worksheet = package.Workbook.Worksheets.First();
        //            int rowCount = worksheet.Dimension.Rows;
        //            int colCount = worksheet.Dimension.Columns;

        //            // Mapeia índice de cada coluna pelo nome
        //            var colMap = new Dictionary<string, int>();
        //            for (int col = 1; col <= colCount; col++)
        //            {
        //                var header = worksheet.Cells[1, col].Text.Trim();
        //                if (!string.IsNullOrEmpty(header))
        //                    colMap[header] = col;
        //            }

        //            for (int row = 2; row <= rowCount; row++) // Pula cabeçalho
        //            {
        //                var item = new OrigemRequest
        //                {
        //                    NomeRazao = colMap.ContainsKey("NomeRazao") ? worksheet.Cells[row, colMap["NomeRazao"]].Text : null,
        //                    IdExterno = colMap.ContainsKey("IdExterno") ? worksheet.Cells[row, colMap["IdExterno"]].Text : null,
        //                    //valo = colMap.ContainsKey("valor_devido") && decimal.TryParse(worksheet.Cells[row, colMap["valor_devido"]].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var vd) ? vd : 0,
        //                    //ValorMulta = colMap.ContainsKey("valor_multa") && decimal.TryParse(worksheet.Cells[row, colMap["valor_multa"]].Text, NumberStyles.Any, CultureInfo.InvariantCulture, out var vm) ? vm : 0,
        //                    //DataSinistro = colMap.ContainsKey("data") && DateTime.TryParse(worksheet.Cells[row, colMap["data"]].Text, out var dt) ? dt : DateTime.MinValue
        //                };

        //                cobrancas.Add(item);
        //            }
        //        }
        //    }

        //    return cobrancas;
        //}


        //private ErroView ValidaCampos
    }
}
