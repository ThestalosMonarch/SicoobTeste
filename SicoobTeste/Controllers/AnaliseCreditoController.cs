using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using SicoobTeste.Models;
using System.ComponentModel;
using System.Linq;

namespace SicoobTeste.Controllers
{
    public class AnaliseCreditoController : Controller
    {
        private readonly SicoobTesteContext _context;
        AnaliseCreditoViewModel analiseCredito = new AnaliseCreditoViewModel();
        public AnaliseCreditoController(SicoobTesteContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Result(string identificador)
        {
            AplicacaoCota aplicacaoCota = _context.AplicacaoCota.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            IAP iap = _context.IAP.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            LimiteCredito limiteCredito = _context.LimiteCredito.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            Cartoes cartoes = _context.Cartoes.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            //var dados = new AnaliseCreditoViewModel();
            if (aplicacaoCota == null)
            {
                analiseCredito.error = "não encontrado!";
            }
            else
            {

                analiseCredito.identificador = identificador;
                analiseCredito.aplicacaoCota = aplicacaoCota;
                analiseCredito.iAP = iap;
                analiseCredito.limiteCredito = limiteCredito;
                analiseCredito.cartoes = cartoes;
                TempData.Put("key", analiseCredito);
            }

            return View(analiseCredito);
        }
        [HttpPost]
        public IActionResult GerarParecer()
        {
            var value = TempData.Get<AnaliseCreditoViewModel>("key");
            /*
            List<string> lista = analiseCredito.GetType().GetProperties().Select(p => p.Name).ToList();
            var dados = string.Join("",lista);*/
            return View(value);
        }
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