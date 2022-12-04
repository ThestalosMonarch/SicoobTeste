using Microsoft.AspNetCore.Mvc;
using SicoobTeste.Models;

namespace SicoobTeste.Controllers
{
    public class AnaliseCreditoController : Controller
    {
        private readonly SicoobTesteContext _context;
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
            AnaliseCreditoViewModel teste = new AnaliseCreditoViewModel();
            AplicacaoCota aplicacaoCota = _context.AplicacaoCota.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            IAP iap = _context.IAP.Where(x => x.CPF_CNPJ == identificador).FirstOrDefault();
            //var dados = new AnaliseCreditoViewModel();
            if (aplicacaoCota == null)
            {
                teste.error = "não encontrado!";
            }
            else
            {
                teste.identificador = identificador;
                teste.aplicacaoCota = aplicacaoCota;
                teste.iAP = iap;

            }
            return View(teste);
        }
    }
}
