namespace SicoobTeste.Services;

using Microsoft.AspNetCore.Html;
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
    public static IHtmlContent FormatContent(string content)
    {
        var lines = content.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        var formattedLines = new List<string>();

        foreach (var line in lines)
        {
            if (line.Contains("Informações Gerais", StringComparison.OrdinalIgnoreCase) ||
                line.Contains("Informações Serasa", StringComparison.OrdinalIgnoreCase))
            {
                formattedLines.Add($"<h1>{line}</h1>");
            }
            else
            {
                formattedLines.Add(line);
            }
        }

        return new HtmlString(string.Join("<br>", formattedLines));
    }
}


