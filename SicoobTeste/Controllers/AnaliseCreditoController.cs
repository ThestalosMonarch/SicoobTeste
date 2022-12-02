using Microsoft.AspNetCore.Mvc;
using SicoobTeste.Models;

namespace SicoobTeste.Controllers
{
    public class AnaliseCreditoController : Controller
    {
        private readonly SicoobTesteContext teste;
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> GetResultAsync(string indetificador)
        {
            var dados = new AnaliseCreditoViewModel
            {
                identificador = indetificador,
                tarifas = teste.Tarifas,

            };

            return View(dados);
        }
    }
}
