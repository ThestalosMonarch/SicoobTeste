using Microsoft.EntityFrameworkCore;

namespace SicoobTeste.Models
{

    [Keyless]
    public class AnaliseCreditoViewModel
    {
        /*Variaveis da classe*/
        public string? identificador { get; set; }
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
        public decimal? TotalContrato { get; set; }
        public decimal? TotalDevedor { get; set; }
        public decimal? MediaEntradaTrimestral { get; set; }
        public decimal? MediaEntradaSemestral { get; set; }
        public decimal? SaldoMedioTrimestral { get; set; }
        public decimal? TotalEmprestimo { get; set; }

        //variaveis da classe que vão ser preenchidas durante a view
        public FormValues? formValues { get; set; }
    }
    //variaveis da classe que vão ser preenchidas durante a view
    public class FormValues
    {
        //dados para servidor público
        private string _finalidade = string.Empty;
        public string finalidade
        {
            get { return _finalidade; }
            set { _finalidade = value ?? string.Empty; }
        }

        private string _servidorPublico = string.Empty;
        public string servidorPublico
        {
            get { return _servidorPublico; }
            set { _servidorPublico = value ?? string.Empty; }
        }
        public string? situacao { get; set; } //aposentado ou trabalhando.
        public string? tipoServidor { get; set; }
        public string? profissao { get; set; }

        //dados para não servidor público

        public string? empresa { get; set; }
        public string? periodo_Empresa { get; set; }

        //valores
        private decimal? _valorCredito;
        public decimal ValorCredito
        {
            get { return _valorCredito ?? 0; }
            set { _valorCredito = value; }
        }

        private decimal? _rendaLiquida;
        public decimal rendaLiquida
        {
            get { return _rendaLiquida ?? 0; }
            set { _rendaLiquida = value; }
        }

        //LimiteCLL
        private decimal? _limiteConcedidoCLL;
        public decimal limiteConcedidoCLL
        {
            get { return _limiteConcedidoCLL ?? 0; }
            set { _limiteConcedidoCLL = value; }
        }

        private decimal? _valorUtilizadoCLL;
        public decimal valorUtilizadoCLL
        {
            get { return _valorUtilizadoCLL ?? 0; }
            set { _valorUtilizadoCLL = value; }
        }
        private string _vencimentoCLL = string.Empty;
        public string vencimentoCLL
        {
            get { return _vencimentoCLL; }
            set { _vencimentoCLL = value ?? string.Empty; }
        }

        //CheckBoxes
        public bool portabilidadesalarial { get; set; }
        public bool demonstrativoano { get; set; }
        public bool impostorenda { get; set; }

        //links externos
        public string _receitaFederal = string.Empty;
        public string receitaFederal
        {
            get { return _receitaFederal; }
            set { _receitaFederal = value ?? string.Empty; }
        }
        public string _historico = string.Empty;
        public string historico
        {
            get { return _historico; }
            set { _historico = value ?? string.Empty; }
        }
        public string _processoTJ = string.Empty;
        public string processoTJ
        {
            get { return _processoTJ; }
            set { _processoTJ = value ?? string.Empty; }
        }
        //Garantias 
        public string _tipoGarantia = string.Empty;
        public string tipoGarantia
        {
            get { return _tipoGarantia; }
            set { _tipoGarantia = value ?? string.Empty; }
        } 
        //Garantia Real campos
        public string _garantiaRealTipos = string.Empty;
        public string garantiaRealTipos
        {
            get { return _garantiaRealTipos; }
            set { _garantiaRealTipos = value ?? string.Empty; }
        }
        private decimal? _garantiaRealValor;
        public decimal garantiaRealValor
        {
            get { return _garantiaRealValor ?? 0; }
            set { _garantiaRealValor = value; }
        }
        #region Garantia Pessoal
        public string _NomeFiador = string.Empty;
        public string NomeFiador
        {
            get { return _NomeFiador; }
            set { _NomeFiador = value ?? string.Empty; }
        }
        public string _CPFFiador = string.Empty;
        public string CPFFiador
        {
            get { return _CPFFiador; }
            set { _CPFFiador = value ?? string.Empty; }
        }
        #endregion 
        
        public string _letra = string.Empty;
        public string letra
        {
            get { return _letra; }
            set { _letra = value ?? string.Empty; }
        }
        private decimal? _limiteAtribuidoCRL;
        public decimal limiteAtribuidoCRL
        {
            get { return _limiteAtribuidoCRL ?? 0; }
            set { _limiteAtribuidoCRL = value; }
        }
        private string _dataCRL = string.Empty;
        public string dataCRL
        {
            get { return _dataCRL; }
            set { _dataCRL = value ?? string.Empty; }
        }
        //Risco da operação
        private string _riscoOperacao = string.Empty;
        public string riscoOperacao
        {
            get { return _riscoOperacao; }
            set { _riscoOperacao = value ?? string.Empty; }
        }
        private string _linhaCredito = string.Empty;
        public string linhaCredito
        {
            get { return _linhaCredito; }
            set { _linhaCredito = value ?? string.Empty; }
        }
        //Condições da Operação
        private decimal? _condicoesOperacaValorTotal;
        public decimal condicoesOperacaValorTotal
        {
            get { return _condicoesOperacaValorTotal ?? 0; }
            set { _condicoesOperacaValorTotal = value; }
        }
        private int? _condicoesOperacaQuantidadeParcela;
        public int condicoesOperacaQuantidadeParcela
        {
            get { return _condicoesOperacaQuantidadeParcela ?? 0; }
            set { _condicoesOperacaQuantidadeParcela = value; }
        }
        private decimal? _condicoesOperacaValorParcelas;
        public decimal condicoesOperacaValorParcelas
        {
            get { return _condicoesOperacaValorParcelas ?? 0; }
            set { _condicoesOperacaValorParcelas = value; }
        }
        //Vencimento
        private string _condicoesOperacaVencimento = string.Empty;
        public string condicoesOperacaVencimento
        {
            get { return _condicoesOperacaVencimento; }
            set { _condicoesOperacaVencimento = value ?? string.Empty; }
        }

        //capacidade de pagamento
        private string _condicoesOperacaCapacidadePagamento= string.Empty;
        public string condicoesOperacaCapacidadePagamento
        {
            get { return _condicoesOperacaCapacidadePagamento; }
            set { _condicoesOperacaCapacidadePagamento = value ?? string.Empty; }
        }
        //seguro prestamista
        private string _seguroPrestamista = string.Empty;
        public string seguroPrestamista
        {
            get { return _seguroPrestamista; }
            set { _seguroPrestamista = value ?? string.Empty; }
        }
        public bool docPropostaCompleta { get; set; }
        public bool fichaCadastralAssinada { get; set; }
        public bool plataformaAtendimento { get; set; }
        public bool conhecaCliente { get; set; }

        private string _outrasCondicoes = string.Empty;
        public string outrasCondicoes
        {
            get { return _outrasCondicoes; }
            set { _outrasCondicoes = value ?? string.Empty; }
        }

        public bool parecerFavoravel { get; set; }
    }

}
