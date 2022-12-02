using Microsoft.EntityFrameworkCore;

namespace SicoobTeste.Models
{

    [Keyless]
    public class AnaliseCreditoViewModel
    {
        public string identificador { get; set; }
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
        public IEnumerable<Tarifas> tarifas { get; set; }

    }
}
