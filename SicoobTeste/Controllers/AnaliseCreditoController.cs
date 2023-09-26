using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SicoobTeste.Models;
using SicoobTeste.Services;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SicoobTeste.Controllers
{
    public class AnaliseCreditoController : Controller
    {
        private readonly SicoobTesteContext _context;

        private readonly AnaliseCreditoService _service;

        public AnaliseCreditoViewModel analiseCredito = new AnaliseCreditoViewModel();
        public AnaliseCreditoController(SicoobTesteContext context, AnaliseCreditoService service)
        {
            _context = context;
            _service = service;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Result(string identificador)
        {
            //Instanciar o cpf do associado.
            PatrimonioCadastroAssociado patrimonioCadastroAssociado = _context.PatrimonioCadastroAssociado.FirstOrDefault(p => p.CPF_CNPJ == identificador);

            if (patrimonioCadastroAssociado == null)
            {
                return NotFound("Não encontrato");
            }

            else
            {
                //Instanciar o restante dos objetos caso o associado exista
                AplicacaoCota? aplicacaoCota = _context.AplicacaoCota.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                IAP? iAP = _context.IAP.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                MargemContribuicao? margemContribuicao = _context.MargemContribuicao.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                LimiteCCL? limiteCCL = _context.LimiteCCL.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                ChequeEspecial? chequeEspecial = _context.ChequeEspecial.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                PreAprovado? preAprovado = _context.PreAprovado.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                SerasaDetalhado? serasaDetalhado = _context.SerasaDetalhado.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                Tarifas? tarifas = _context.Tarifas.FirstOrDefault(p => p.CPF_CNPJ == identificador);

                decimal? mediaEntradaTrimestral = 0;
                decimal? mediaEntradaSemestral = 0;
                decimal? saldoMedioTrimestral = 0;

                try
                {
                    var recentItems = _context.MediaEntradaSemestral.Where(p => p.CPF_CNPJ == identificador);
                    DateTime mostRecentMonth = recentItems.Max(p => p.Datas).Date;
                    DateTime threeMonthsAgo = mostRecentMonth.AddMonths(-3);
                    var itemsInLast3Months = recentItems.Where(p => p.Datas > threeMonthsAgo);
                    mediaEntradaTrimestral = itemsInLast3Months.Average(x => x.LancamentoCredito);
                    mediaEntradaSemestral = _context.MediaEntradaSemestral.Where(p => p.CPF_CNPJ == identificador).Average(x => x.LancamentoCredito);
                    saldoMedioTrimestral = _context.MediaTrimestral.Where(p => p.CPF_CNPJ == identificador).Average(x => x.SaldoMedio);
                }
                catch (Exception ex)
                { }

                List<Cartoes>? cartoes = _context.Cartoes.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<EndividamentoInterno>? endividamentoInternos = _context.EndividamentoInterno.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<Garantias>? garantias = _context.Garantias.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<EndividamentoExterno>? endividamentoExternos = _context.EndividamentoExterno.Where(x => x.CPF_CNPJ == identificador).ToList();


                {
                    identificador = identificador.Trim();
                    analiseCredito.patrimonioCadastroAssociado = patrimonioCadastroAssociado;
                    analiseCredito.aplicacaoCota = aplicacaoCota;
                    analiseCredito.iAP = iAP;
                    analiseCredito.cartoes = cartoes;
                    analiseCredito.endividamentoInterno = endividamentoInternos;
                    analiseCredito.garantias = garantias;
                    analiseCredito.endividamentoExterno = endividamentoExternos;
                    analiseCredito.margemContribuicao = margemContribuicao;
                    analiseCredito.limiteCCL = limiteCCL;
                    analiseCredito.chequeEspecial = chequeEspecial;
                    analiseCredito.preAprovado = preAprovado;
                    analiseCredito.serasaDetalhado = serasaDetalhado;
                    analiseCredito.tarifas = tarifas;
                    analiseCredito.MediaEntradaSemestral = mediaEntradaTrimestral;
                    analiseCredito.MediaEntradaTrimestral = mediaEntradaTrimestral;
                    analiseCredito.SaldoMedioTrimestral = saldoMedioTrimestral;
                    //calcular valores para variáveis de cálculo
                    _service.CalculateTotalsSaldoDevedor(analiseCredito);
                    _service.GetCorrectIdade(analiseCredito);
                    TempData
                        .Put("key", analiseCredito);
                }

                return View("Result", analiseCredito);
            }

        }

        [HttpPost]
        public IActionResult GerarParecer(FormValues formValues)
        {

            var model = TempData.Get<AnaliseCreditoViewModel>("key");
            model.formValues = formValues;
            //Adicionar linhas com as informações
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Informações Gerais");
            sb.AppendLine($"Nome: {model.patrimonioCadastroAssociado.Nome}");
            sb.AppendLine($"Idade: {model.patrimonioCadastroAssociado.Idade}");
            sb.AppendLine($"Finalidade: {model.formValues.finalidade}");
            sb.AppendLine($"Associado Desde: {model.patrimonioCadastroAssociado.DataInicioRelacionamento.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Ultima renovação cadastral: {model.patrimonioCadastroAssociado.DataUltimaRenovacaoCadastral.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Servidor Público: {model.formValues.servidorPublico}");
            if (model.formValues.servidorPublico.Equals("sim"))
            {
                sb.AppendLine($"Aposentado/Ativo: {model.formValues.situacao}");
                sb.AppendLine($"Tipo de Servidor: {model.formValues.tipoServidor}");
            }
            else
            {
                sb.AppendLine($"Profissão: {model.formValues.profissao}");
                sb.AppendLine($"Empresa: {model.formValues.empresa}");
                sb.AppendLine($"Período na Empresa: {model.formValues.periodo_Empresa}");
            }
            
            sb.AppendLine($"Valor Crédito: {model.formValues.ValorCredito}");
            sb.AppendLine($"Renda Bruta: {model.patrimonioCadastroAssociado.RendaBrutaMensal}");
            sb.AppendLine($"Renda Liquida: {model.formValues.rendaLiquida}");

            //-----------------------------
            sb.AppendLine("Relacionamento");
            sb.AppendLine($"Cota Capital: {model.aplicacaoCota?.SaldoClienteContaCapitalDiario}");
            sb.AppendLine($"Aplicação: {model.aplicacaoCota?.SaldoDiarioRDC}");
            sb.AppendLine($"Margem de contribuição: {model.margemContribuicao?.ResultadoAssociados}");

            #region IAP
            sb.AppendLine("Produtos IAP do Cooperado:");
            if (model.iAP != null)
            {
                foreach (PropertyInfo propertyInfo in model.iAP.GetType().GetProperties())
                {
                    var val = propertyInfo.GetValue(model.iAP);
                    if (val != null && val.ToString().Contains("SIM"))
                    {
                        sb.AppendLine(propertyInfo.Name);
                    }
                }

            }
            else
            {
                sb.AppendLine("Sem IAP");
            }
            #endregion
            sb.AppendLine("Cheque Especial");
            sb.AppendLine($"Cheque Especial - Valor Contratado: {model.chequeEspecial?.ValorLimiteCreditoContratato}");
            sb.AppendLine($"Cheque Especial - Valor Utilizado: {model.chequeEspecial?.ValorUtilizado}");
            sb.AppendLine($"Cheque Especial - Dias Usados: {model.chequeEspecial?.QuantidadeDiasUtilizacao}");
            sb.AppendLine("Limite CCL");
            sb.AppendLine($"Limite CLL - Limite Concedido: {model.limiteCCL?.ValorLimiteConcedido}");
            sb.AppendLine($"Limite CLL - Valor Utilizado: {model.limiteCCL?.ValorLimiteUtilizado}");
            sb.AppendLine($"Limite CLL - Vencimento: {model.limiteCCL?.DataVigenciaLimite}");
            sb.AppendLine("Limite Utilizado Pré Aprovado");
            sb.AppendLine($"Limite Pré Aprovado - Valor Contratado: {model.preAprovado?.ValorLimiteContratado}");
            sb.AppendLine($"Limite Pré Aprovado - Valor Limite Utilizado: {model.preAprovado?.ValorLimiteUtilizado}");
            sb.AppendLine("Informações Externas");
            sb.AppendLine("Garantias - Tipo da Garantia e seus dados:");
            if (model.formValues.tipoGarantia.Equals("Garantia Real"))
            {
                sb.AppendLine($"{model.formValues.tipoGarantia}");
                sb.AppendLine($"Tipos: {model.formValues.tipoGarantia}");
                sb.AppendLine($"Valor: {model.formValues.garantiaRealValor}");
            }
            else
            {
                sb.AppendLine($"{ model.formValues.tipoGarantia}");
                sb.AppendLine($"Nome do Fiador: {model.formValues.NomeFiador}");
                sb.AppendLine($"CPF Do Fiador: {model.formValues.CPFFiador}");
            }
            sb.AppendLine("Condições de Crédito");
            sb.AppendLine($"Enquadramento: {model.patrimonioCadastroAssociado.DataUltimaRenovacaoCadastral.ToString("dd/MM/yyyy")}");
            sb.AppendLine($"Pré Aprovado - Limite Contratado: {model.preAprovado?.ValorLimiteContratado}");
            sb.AppendLine($"Pré Aprovado - Pré Aprovado: {model.preAprovado?.ValorLimiteUtilizado}");

            var cartao = model.cartoes?.OrderByDescending(c => c.Datas).FirstOrDefault();

            if (cartao != null)
            {
                string vencimento = cartao.DividaConsolidada > cartao.LimiteUtilizado ? "Sim" : "Não";
                sb.AppendLine($"Divida Consolidada: {cartao.DividaConsolidada}");
                sb.AppendLine($"Limite Atribuído: {cartao.LimiteAtribuido}");
                sb.AppendLine($"Limite Disponível: {cartao.LimiteDisponivel}");
                sb.AppendLine($"Limite Utilizado: {cartao.LimiteUtilizado}");
                sb.AppendLine($"Vencido?: {vencimento}");
            }
            else
            {
                sb.AppendLine("sem cartões!");
            }
            //saldo devedor
            sb.AppendLine("Endividamento Intero do Cooperado");
            if (model.endividamentoInterno != null)
            {
                foreach (var item in model.endividamentoInterno)
                {
                    sb.AppendLine($"Divida Consolidada: {item.ModalidadeProduto}");
                    sb.AppendLine($"Limite Atribuído: {item.ValorContrato}");
                    sb.AppendLine($"Limite Disponível: {item.QuantidadeParcelas}");
                    sb.AppendLine($"Limite Utilizado: {item.QuantidadeParcelasAbertas}");
                    sb.AppendLine($"Vencido?: {item.SaldoDevedorDiario}");
                    sb.AppendLine("INAD 15 Maior que zero?");
                    if (item.INAD15 > 0)
                    {
                        sb.AppendLine("Sim");
                    }
                    else
                    {
                        sb.AppendLine("Sim");
                    }
                    sb.AppendLine("INAD 90 Maior que zero?");
                    if (item.INAD90 > 0)
                    {
                        sb.AppendLine("Sim");
                    }
                    else
                    {
                        sb.AppendLine("Sim");
                    }
                    sb.AppendLine("INAD saldo devedor Maior que zero?");
                    if (item.SaldoDevedorDiario > 0)
                    {
                        sb.AppendLine("Sim");
                    }
                    else
                    {
                        sb.AppendLine("Sim");
                    }
                }
                sb.AppendLine($"Total do Contrato:{model.TotalContrato}");
                sb.AppendLine($"Total Devedor:{model.TotalDevedor}");
            }

            sb.AppendLine($"Media Entrada Trimestral: {model.MediaEntradaTrimestral}");
            sb.AppendLine($"Media Entrada Semestral: {model.MediaEntradaSemestral}");
            sb.AppendLine($"Saldo Medio Trimestral: {model.SaldoMedioTrimestral}");
            sb.AppendLine($"Seguro Prestamista: ");
            sb.AppendLine($"Pacote Tarifa: {model.tarifas?.Tarifa}");
            sb.AppendLine("Informações Serasa");
            if (model.serasaDetalhado != null)
            {
                sb.AppendLine($"Score: {model.serasaDetalhado.Score}");
            }
            else
            {
                sb.AppendLine("Sem dados sobre o Serasa!");
            }
            //CRL
            sb.AppendLine("CRL");
            sb.AppendLine($"Letra: { model.formValues.letra}");
            sb.AppendLine($"Limite Atribuido: { model.formValues.limiteAtribuidoCRL}");
            sb.AppendLine($"Data da Classificação: { model.formValues.dataCRL}");
            sb.AppendLine($"Risco da Operação: { model.formValues.riscoOperacao}");
            sb.AppendLine($"Linha de Crédito: { model.formValues.linhaCredito}");
            sb.AppendLine("Condições da Operação");
            sb.AppendLine($"Valor Total: {model.formValues.condicoesOperacaValorTotal}");
            sb.AppendLine($"Quantidade de Parcela: {model.formValues.condicoesOperacaValorParcelas}");
            sb.AppendLine($"Valor das Parcelas: {model.formValues.condicoesOperacaValorParcelas}");
            sb.AppendLine($"Vencimento:{model.formValues.condicoesOperacaVencimento}");
            sb.AppendLine($"Capacidade de Pagamento:{model.formValues.condicoesOperacaCapacidadePagamento}");
            sb.AppendLine($"Seguro Prestamista:{model.formValues.seguroPrestamista}");
            string allValues = sb.ToString();
            /*
            List<string> lista = analiseCredito.GetType().GetProperties().Select(p => p.Name).ToList();
            var dados = string.Join("",lista);*/
            return View("GerarParecer", allValues);
        }
        [HttpPost]
        public IActionResult EditarParecer()
        {
            var value = TempData.Get<AnaliseCreditoViewModel>("key");
            /*
            List<string> lista = analiseCredito.GetType().GetProperties().Select(p => p.Name).ToList();
            var dados = string.Join("",lista);*/
            return View(value);

        }
        [HttpPost]
        public IActionResult CalcularCapacidadePagamento(decimal valorParcelas, decimal rendaBrutaMensal, decimal valorVencerAte360Dias)
        {

            decimal? capacidadePagamento = ((valorVencerAte360Dias / 12) + valorParcelas) - rendaBrutaMensal;
            capacidadePagamento = Math.Abs(capacidadePagamento ?? 0);
            // Return the calculated value as JSON response
            return Json(capacidadePagamento);

        }
        public IActionResult CalcularSeguroPrestamista(decimal valorTotalEmprestimo, decimal saldoTotalDevedor, int idade)
        {
            string reposta = "";
            decimal? prestamista = valorTotalEmprestimo + saldoTotalDevedor;
            switch (idade)
            {
                case int n when n >= 14 && n <= 65:
                    if (prestamista <= 3000000)
                        reposta = "Sim";
                    break;
                case int n when n >= 66 && n <= 70:
                    if (prestamista <= 500000)
                        reposta = "Sim";
                    break;

                case int n when n >= 71 && n <= 75:
                    if (prestamista <= 75000)
                        reposta = "Sim";
                    break;

                case int n when n >= 76 && n <= 80:
                    if (prestamista <= 50000)
                        reposta = "Sim";
                    break;

                case int n when n >= 81 && n <= 85:
                    if (prestamista <= 25000)
                        reposta = "Sim";
                    break;

                default:
                    reposta = "Não";
                    break;
            }
            return Json(reposta);
        }
    }
}