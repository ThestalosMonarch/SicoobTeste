using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SicoobTeste.Models;
using SicoobTeste.Services;
using System.ComponentModel;
using System.Linq;

namespace SicoobTeste.Controllers
{
    public class AnaliseCreditoController : Controller
    {
        private readonly SicoobTesteContext _context;

        private readonly AnaliseCreditoService _service;

        private AnaliseCreditoViewModel analiseCredito = new AnaliseCreditoViewModel();
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
                Tarifas tarifas = _context.Tarifas.FirstOrDefault(p => p.CPF_CNPJ == identificador);


                decimal mediaEntradaTrimestral = 0;
                decimal mediaEntradaSemestral = 0;
                decimal saldoMedioTrimestral = 0;
                var recentItems = _context.MediaEntradaSemestral.Where(p => p.CPF_CNPJ == identificador);
                DateTime mostRecentMonth = recentItems.Max(p => p.Datas).Date;
                DateTime threeMonthsAgo = mostRecentMonth.AddMonths(-3);
                var itemsInLast3Months = recentItems.Where(p => p.Datas > threeMonthsAgo);

                try
                {
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
                    analiseCredito.MediaEntradaSemestral = mediaEntradaSemestral;
                    //calcular valores para variáveis de cálculo
                    _service.CalculateTotalsSaldoDevedor(analiseCredito);
                    _service.GetCorrectIdade(analiseCredito);
                }
                
                return View(analiseCredito);
            }

        }
        [HttpGet]
        public IActionResult GerarParecer()
        {
            var value = TempData.Get<AnaliseCreditoViewModel>("key");
            /*
            List<string> lista = analiseCredito.GetType().GetProperties().Select(p => p.Name).ToList();
            var dados = string.Join("",lista);*/
            return View(value);
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