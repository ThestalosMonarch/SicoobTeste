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
        public async Task<IActionResult> Result(string identificador)
        {
            var dados = new AnaliseCreditoViewModel();
            if (string.IsNullOrEmpty(identificador))
            {
                dados.error = "sem dados encontrados para o CPF digitado!";
            }
            else
            {
                dados = new AnaliseCreditoViewModel
                {
                    identificador = identificador,
                    tarifas = teste.Tarifas,

                };
               
            }
            return View(dados);
        }
    }
}
