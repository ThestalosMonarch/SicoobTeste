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
                LimiteCCL? limiteCCL  = _context.LimiteCCL.FirstOrDefault(p => p.CPF_CNPJ == identificador); 
                ChequeEspecial? chequeEspecial = _context.ChequeEspecial.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                PreAprovado? preAprovado = _context.PreAprovado.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                SerasaDetalhado? serasaDetalhado = _context.SerasaDetalhado.FirstOrDefault(p => p.CPF_CNPJ == identificador);   
                Tarifas tarifas = _context.Tarifas.FirstOrDefault(p => p.CPF_CNPJ == identificador);
                

                decimal mediaEntradaTrimestral = 0;
                decimal mediaEntradaSemestral = 0;
                decimal saldoMedioTrimestral = 0;

                try
                {
                    mediaEntradaTrimestral = _context.MediaTrimestral.Where(p => p.CPF_CNPJ == identificador).Sum(x => x.SaldoMedio);
                    mediaEntradaSemestral = _context.MediaEntradaSemestral.Where(p => p.CPF_CNPJ == identificador).Sum(x => x.LancamentoCredito);
                   //saldoMedioTrimestral =
                }
                catch (Exception ex)
                {}

                List<Cartoes>? cartoes = _context.Cartoes.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<EndividamentoInterno>? endividamentoInternos = _context.EndividamentoInterno.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<Garantias>? garantias = _context.Garantias.Where(x => x.CPF_CNPJ == identificador).ToList();
                List<EndividamentoExterno>? endividamentoExternos = _context.EndividamentoExterno.Where(x => x.CPF_CNPJ == identificador).ToList();

                AnaliseCreditoViewModel analiseCredito = new AnaliseCreditoViewModel();
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
    }
}