namespace SicoobTeste.Services;
using SicoobTeste.Models;
using System.Collections;
using System.Globalization;
using System.Reflection;

public class AnaliseCreditoService
{
    /// <summary>
    /// utiliza da lista de endividamento internos para calcular a divida total de 
    /// contrato e divida total diária.
    /// </summary>
    /// <param name="model"></param>
    public void CalculateTotalsSaldoDevedor(AnaliseCreditoViewModel model)
    {
        if (model.endividamentoInterno != null && model.endividamentoInterno.Any())
        {
            model.TotalContrato = model.endividamentoInterno.Sum(e => e.ValorContrato);
            model.TotalDevedor = model.endividamentoInterno.Sum(e => e.SaldoDevedorDiario);
        }
        else
        {
            model.TotalContrato = 0;
            model.TotalDevedor = 0;
        }
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
    public void SeguroPrestamista(AnaliseCreditoViewModel model)
    {
        decimal divida = model.TotalDevedor + model.TotalEmprestimo;
        /*
        switch (model.patrimonioCadastroAssociado.Idade)
        {
            case int n when n >= 14 && n <= 65:
                if (divida <= 3000000)
                    result = "Yes";
                break;

            case int n when n >= 66 && n <= 70:
                if (divida <= 500000)
                    result = "Yes";
                break;

            case int n when n >= 71 && n <= 75:
                if (divida <= 75000)
                    result = "Yes";
                break;

            case int n when n >= 76 && n <= 80:
                if (divida <= 50000)
                    result = "Yes";
                break;

            case int n when n >= 81 && n <= 85:
                if (divida <= 25000)
                    result = "Yes";
                break;

            default:
                divida = "No";
                break;
        }
        */
    }
}


