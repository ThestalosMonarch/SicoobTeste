namespace SicoobTeste.Services;
using SicoobTeste.Models;


public class AnaliseCreditoService
{
    /// <summary>
    /// utiliza da lista de endividamento internos para calcular a divida total de 
    /// contrato e divida total diária.
    /// </summary>
    /// <param name="model"></param>
    public void CalculateTotalsSaldoDevedor(AnaliseCreditoViewModel model)
    {
        if (!string.IsNullOrEmpty(model.TotalContrato.ToString()) & !string.IsNullOrEmpty(model.TotalDevedor.ToString()))
        {
            model.TotalContrato = model.endividamentoInterno.Sum(e => e.ValorContrato);
            model.TotalDevedor = model.endividamentoInterno.Sum(e => e.SaldoDevedorDiario);
        }
        model.TotalContrato = 0;
        model.TotalDevedor = 0;
    }

    public void GetCorrectIdade(AnaliseCreditoViewModel model)
    {
      
        DateTime currentDate = DateTime.Now; // current date
        int age = currentDate.Year - model.patrimonioCadastroAssociado.DataNascimento.Year;
        if (currentDate < model.patrimonioCadastroAssociado.DataNascimento.AddYears(age))
        {
            age--;
        }
        model.patrimonioCadastroAssociado.Idade = age;
    }
    public void CalcularMedias(AnaliseCreditoViewModel model)
    {

    }
}

