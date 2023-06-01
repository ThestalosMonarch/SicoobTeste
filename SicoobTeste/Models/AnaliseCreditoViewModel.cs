using Microsoft.EntityFrameworkCore;

namespace SicoobTeste.Models
{

    [Keyless]
    public class AnaliseCreditoViewModel
    {
        /*Variaveis da classe*/
        public string? identificador { get; set; }
        //variaveis da classe que vão ser preenchidas durante a view
        public string? finalidade { get; set; }
        public string? servidorPublico { get; set; }
        public string? situacao { get; set; }
        public string? tipoServidor { get; set; }
        public string? profissao { get; set; }

        //Variaveis de outras classes
        public PatrimonioCadastroAssociado? patrimonioCadastroAssociado { get; set; }
        public MargemContribuicao? margemContribuicao { get; set; }
        public ChequeEspecial? chequeEspecial { get; set; }
        public LimiteCCL? limiteCCL { get; set; }
        public PreAprovado? preAprovado { get; set; }
        public AplicacaoCota? aplicacaoCota { get; set; }
        public SerasaDetalhado? serasaDetalhado { get; set; }

        public Tarifas? tarifas { get; set; }
        public IAP? iAP { get; set; }
        public List<Cartoes>? cartoes { get; set; }
        public List<EndividamentoInterno>? endividamentoInterno { get; set; }
        public List<Garantias>? garantias { get; set; }
        public List<EndividamentoExterno>? endividamentoExterno { get; set; }
        
        //Variáveis que são somas de outras informções
        public decimal TotalContrato { get; set; }
        public decimal TotalDevedor { get; set; }
        public decimal MediaEntradaTrimestral { get; set; }
        public decimal MediaEntradaSemestral { get; set; }
        public decimal SaldoMedioTrimestral { get; set; }
        public decimal TotalEmprestimo { get; set; }
    }
}
