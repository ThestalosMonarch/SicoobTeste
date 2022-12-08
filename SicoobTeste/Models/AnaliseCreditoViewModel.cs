using Microsoft.EntityFrameworkCore;

namespace SicoobTeste.Models
{

    [Keyless]
    public class AnaliseCreditoViewModel
    {
        /*Variaveis da classe*/
        public string identificador { get; set; }
        public string doc_propostaCompleta { get; set; }
        public string anexadoPlataformaAtendimento { get; set; }
        public string questionarioCliente { get; set; }
        public string outrasCondicoes { get; set; }
        public string error { get; set; }

        /*Variaveis de outras classes*/
        public AplicacaoCota aplicacaoCota { get; set; }
        public Cartoes cartoes { get; set; }
        public Endividamento endividamento { get; set; }
        public EndividamentoExterno endividamentoExterno { get; set; }
        public EndividamentoInterno endividamentoInterno { get; set; }
        public IAP iAP { get; set; }
        public LimiteCredito limiteCredito { get; set; }    
        public MargemContribuicao margemContribuicao { get; set; }
        public MediaEntradaSemestral mediaEntradaSemestral { get; set; }
        public MediaEntradaTrimestral mediaEntradaTrimestral { get; set; }
        public PatrimonioCadastroAssociado patrimonioCadastro { get; set; }
        public SerasaDetalhado serasaDetalhado { get; set; }
        public Tarifas tarifas { get; set; }

    }
}
