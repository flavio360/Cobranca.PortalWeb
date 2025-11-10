using AutoMapper;
using Cobranca.PortalWeb.Models.Request.Cobranca;
using Cobranca.PortalWeb.Models.Response.Cobranca;
using Cobranca.PortalWeb.Models.ViewModel.Cobranca;
using Cobranca.PortalWeb.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Cobranca.PortalWeb.Controllers.Cobranca
{
    [Route("Cobranca")]
    public class CobrancaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICobrancaService _cobrancaService;
        public CobrancaController(IMapper mapper, ICobrancaService cobrancaService) 
        {
            _mapper = mapper;
            _cobrancaService = cobrancaService;
        }

        [HttpGet("Listar")]
        [HttpGet("Listar/{id:int}")]
        public async Task<IActionResult> Listar(int? id, [FromQuery] CobrancaRequest? filtros)
        {
            //var ocorrencia = await _Service.GetById(id);
            var response = new List<CobrancaCapaResponse>();
            response = await _cobrancaService.CobrancaListaCapa(filtros);
            var viewModel = _mapper.Map<List<CobrancaCapaViewModel>>(response);


            return View(viewModel);
        }


        [HttpGet("CobrancaDetalhe/{id:int}")]
        public async Task<IActionResult> CobrancaDetalhe(int id)
        {

            var response = new List<CobrancaDetalheViewModel>
{
    new CobrancaDetalheViewModel
    {
        // 🔹 Dados da origem / ocorrência
        TipoOrigem = "SINISTRO",
        IdExterno = "12243271",
        Titulo = "Sinistro Auto 00011222",
        Descricao = "Colisão traseira em via pública",
        DataEvento = new DateTime(2025, 07, 10),
        CreatedAt = new DateTime(2025, 08, 23, 20, 31, 05),

        // 🔹 Credor
        Cnpj = "11.111.111/0001-11",
        NomeCredor = "Marmitas Delícia",

        // 🔹 Dados financeiros
        ValorPrincipal = 1200.50m,
        Vencimento = new DateTime(2025, 11, 10),
        StatusCobranca = 1,
        DespesasTotal = 150.75m,
        CorrecaoIndice = "IPCA",
        FranquiaValor = 200.00m,
        JurosDataBase = new DateTime(2025, 11, 01),
        MultaPercentual = 2.50m,
        NegDescontoVista = 50.00m,
        NegMaxParcelas = 6,
        NegMinValorParcela = 200.00m,
        NegValidade = new DateTime(2025, 12, 31),
        ValorTotalInicial = 1551.25m,

        // 🔹 Devedores
        devedorModel = new List<DevedorModel>
        {
            new DevedorModel
            {
                ParteId = 28,
                NomeDevedor = "Melequinha de Jesus",
                Tipo = "PF",
                DataNascimento = new DateTime(1988, 05, 12),
                CpfCnpj = "77773111",
                RG_IE = "221311",
                Tel1 = "+5511990000000",
                Tel2 = "+5511988888888",
                Email = "carlos.souza@example.com",
                EndLogradouro = "Av. Paulista",
                EndNumero = "1000",
                EndComplemento = "Apto 101",
                EndBairro = "Bela Vista",
                EndCidade = "São Paulo",
                EndUF = "SP",
                EndCEP = "01311000"
            },
            new DevedorModel
            {
                ParteId = 29,
                NomeDevedor = "Maria dos Santos",
                Tipo = "PF",
                DataNascimento = new DateTime(1990, 03, 25),
                CpfCnpj = "88888222",
                RG_IE = "445566",
                Tel1 = "+5511988889999",
                Tel2 = "+5511977776666",
                Email = "maria.santos@example.com",
                EndLogradouro = "Rua das Flores",
                EndNumero = "500",
                EndComplemento = "Casa 2",
                EndBairro = "Jardim América",
                EndCidade = "São Paulo",
                EndUF = "SP",
                EndCEP = "01448000"
            }
        },

        // 🔹 Respostas (pagamentos / tentativas)
        respostaModel = new List<RespostaModel>
        {
            new RespostaModel
            {
                PaidAt = new DateTime(2025, 10, 01, 14, 20, 00),
                Valor = 400.00m,
                Metodo = "PIX",
                Body = "{\"status\":\"approved\",\"transaction_id\":\"TX12345\"}",
                MediaType = "application/json"
            },
            new RespostaModel
            {
                PaidAt = new DateTime(2025, 10, 10, 9, 45, 00),
                Valor = 800.00m,
                Metodo = "BOLETO",
                Body = "{\"status\":\"pending\"}",
                MediaType = "application/json"
            },
            new RespostaModel
            {
                PaidAt = null,
                Valor = 351.25m,
                Metodo = null,
                Body = null,
                MediaType = null
            }
        }
    }

    // Se quiser adicionar mais itens à lista, adicione mais "new CobrancaDetalheViewModel { ... }" aqui.
};


            //var ocorrencia = await _Service.GetById(id);
            //var response = new List<CobrancaDetalheResponse>();

            //response = await _cobrancaService.CobrancaDetalhe(id);
            //var viewModel = _mapper.Map<List<CobrancaDetalheViewModel>>(response);


            return View("CobrancaDetalhe", response);
        }


        [HttpGet]
        [Route("Nova")]
        public async Task<IActionResult> Nova()
        {
            return View();
        }


        [HttpPut]
        [Route("Editar/")]
        public async Task<IActionResult> Editar(int id)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var ocorrencia = await _Service.GetById(id);
            if (true)
            {
                return NotFound();
            }
            return View();
        }
    }
}
