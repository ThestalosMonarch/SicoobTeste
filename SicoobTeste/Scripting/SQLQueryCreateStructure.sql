-- ************************************** [AplicacaoCota]
CREATE TABLE [AplicacaoCota]
(
 [AplicacaoCotaID]                int NOT NULL ,
 [CPF_CNPJ]                       varchar(20) NOT NULL ,
 [SaldoDiarioRDC]                 decimal(18,2) NOT NULL ,
 [SaldoClienteContaCapitalDiario] decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_AplicacaoCotaID] PRIMARY KEY CLUSTERED ([AplicacaoCotaID] ASC)
);
-- ************************************** [Cartoes]
CREATE TABLE [Cartoes]
(
 [CartoesID]         int NOT NULL ,
 [CPF_CNPJ]          varchar(20) NOT NULL ,
 [DividaConsolidada] decimal(18,2) NOT NULL ,
 [LimiteAtribuido]   decimal(18,2) NOT NULL ,
 [LimiteDisponivel]  decimal(18,2) NOT NULL ,
 [LimiteUtilizado]   decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_CartoesID] PRIMARY KEY CLUSTERED ([CartoesID] ASC)
);
-- ************************************** [CartoesTrimestre]
CREATE TABLE [CartoesTrimestre]
(
 [CartoesTrimestreID] int NOT NULL ,
 [CPF_CNPJ]           varchar(20) NOT NULL ,
 [DividaConsolidada]  decimal(18,2) NOT NULL ,
 [LimiteAtribuido]    decimal(18,2) NOT NULL ,
 [LimiteDisponivel]   decimal(18,2) NOT NULL ,
 [LimiteUtilizado]    decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_CartoesTrimestreID] PRIMARY KEY CLUSTERED ([CartoesTrimestreID] ASC)
);
-- ************************************** [Endividamento]
CREATE TABLE [Endividamento]
(
 [EndividamentoID]    int NOT NULL ,
 [CPF_CNPJ]           varchar(20) NOT NULL ,
 [OrigemPrejuizo]     varchar(30) NOT NULL ,
 [SubmodalidadeBacen] varchar(120) NOT NULL ,
 [DiasAtrasoParcela]  int NOT NULL ,
 [SaldoDevedorDiario] decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_EndividamentoID] PRIMARY KEY CLUSTERED ([EndividamentoID] ASC)
);
-- ************************************** [EndividamentoExterno]
CREATE TABLE [EndividamentoExterno]
(
 [EndividamentoExternoID] int NOT NULL ,
 [CPF_CNPJ]               varchar(20) NOT NULL ,
 [SubmodalidadeBacen]     text NOT NULL ,
 [ValorVencerAte360Dias]  decimal(18,2) NOT NULL ,
 [ValorVencerApos360Dias] decimal(18,2) NOT NULL ,
 [ValorVencido]           decimal(18,2) NOT NULL ,
 [Prejuizo]               decimal(18,2) NOT NULL ,
 [SaldoDevedor]           decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_EndividamentoExternoID] PRIMARY KEY CLUSTERED ([EndividamentoExternoID] ASC)
);
-- ************************************** [EndividamentoInterno]
CREATE TABLE [EndividamentoInterno]
(
 [EndividamentoInternoID]    int NOT NULL ,
 [CPF_CNPJ]                  varchar(20) NOT NULL ,
 [ModalidadeProduto]         varchar(50) NOT NULL ,
 [QuantidadeParcelas]        int NOT NULL ,
 [QuantidadeParcelasAbertas] int NOT NULL ,
 [ValorContrato]             decimal(18,2) NOT NULL ,
 [SaldoDevedorDiario]        decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_EndividamentoInternoID] PRIMARY KEY CLUSTERED ([EndividamentoInternoID] ASC)
);
-- ************************************** [IAP]
CREATE TABLE [IAP]
(
 [IAPID]                     int NOT NULL ,
 [CPF_CNPJ]                  varchar(20) NOT NULL ,
 [CartaoCredito]             varchar(10) NOT NULL ,
 [PacoteTarifas]             varchar(10) NOT NULL ,
 [QuantidadeProduto]         int NOT NULL ,
 [SIPAG]                     varchar(10) NOT NULL ,
 [Previdencia]               varchar(10) NOT NULL ,
 [CartaoDebito]              varchar(10) NOT NULL ,
 [ProdutorRural]             varchar(10) NOT NULL ,
 [TituloDescontado]          varchar(10) NOT NULL ,
 [SeguroVida]                varchar(10) NOT NULL ,
 [SeguroGeral]               varchar(10) NOT NULL ,
 [SeguroVidaPF_PJ]           varchar(10) NOT NULL ,
 [VidaPrestamista]           varchar(10) NOT NULL ,
 [SeguroRural]               varchar(10) NOT NULL ,
 [SeguroMassificados]        varchar(10) NOT NULL ,
 [SeguroAuto]                varchar(10) NOT NULL ,
 [ProdutoRDC]                varchar(10) NOT NULL ,
 [PreAprovado]               varchar(10) NOT NULL ,
 [LCI]                       varchar(10) NOT NULL ,
 [LCA]                       varchar(10) NOT NULL ,
 [Investimento]              varchar(10) NOT NULL ,
 [Financiamento]             varchar(10) NOT NULL ,
 [Emprestimo]                varchar(10) NOT NULL ,
 [CreditoRural]              varchar(10) NOT NULL ,
 [ContaCapital]              varchar(10) NOT NULL ,
 [Servicos]                  varchar(10) NOT NULL ,
 [Moto]                      varchar(10) NOT NULL ,
 [Automovel]                 varchar(10) NOT NULL ,
 [Consorcio]                 varchar(10) NOT NULL ,
 [Cobrança]                  varchar(10) NOT NULL ,
 [ChequeEspecial]            varchar(10) NOT NULL ,
 [DebitoAutomaticoEfetivado] varchar(10) NOT NULL ,
 [ContaCorrenteInativa]      varchar(10) NOT NULL ,
 [SicoobNet]                 varchar(10) NOT NULL ,
 [MobileBanking]             varchar(10) NOT NULL ,
 [SicoobEmpresarial]         varchar(10) NOT NULL ,


 CONSTRAINT [PK_IAPID] PRIMARY KEY CLUSTERED ([IAPID] ASC)
);
-- ************************************** [LimiteCredito]
CREATE TABLE [LimiteCredito]
(
 [LimiteCreditoID]             int NOT NULL ,
 [CPF_CNPJ]                    varchar(20) NOT NULL ,
 [LimiteCreditoContrato]       decimal(18,2) NOT NULL ,
 [SaldoDevedorFinal]           decimal(18,2) NOT NULL ,
 [DiasUtilizacaoLimiteCredito] int NOT NULL ,


 CONSTRAINT [PK_LimiteCreditoID] PRIMARY KEY CLUSTERED ([LimiteCreditoID] ASC)
);
-- ************************************** [MargemContribuicao]
CREATE TABLE [MargemContribuicao]
(
 [MargemContribuicaoID] int NOT NULL ,
 [CPF_CNPJ]             varchar(20) NOT NULL ,
 [ResultadoAssociados]  decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_MargemContribuicaoID] PRIMARY KEY CLUSTERED ([MargemContribuicaoID] ASC)
);
-- ************************************** [MediaEntradaSemestral]
CREATE TABLE [MediaEntradaSemestral]
(
 [MediaEntradaSemestralID] int NOT NULL ,
 [CPF_CNPJ]                varchar(20) NOT NULL ,
 [LancamentoCredito]       decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_MediaEntradaSemestralID] PRIMARY KEY CLUSTERED ([MediaEntradaSemestralID] ASC, [CPF_CNPJ] ASC)
);
-- ************************************** [MediaEntradaTrimestral]
CREATE TABLE [MediaEntradaTrimestral]
(
 [MediaEntradaTrimestralID] int NOT NULL ,
 [CPF_CNPJ]                 varchar(20) NOT NULL ,
 [LancamentoCredito]        decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_MediaEntradaTrimestralID] PRIMARY KEY CLUSTERED ([MediaEntradaTrimestralID] ASC)
);
-- ************************************** [PatrimonioCadastroAssociado]
CREATE TABLE [PatrimonioCadastroAssociado]
(
 [PatrimonioCadastroAssociadoID] int NOT NULL ,
 [CPF_CNPJ]                      varchar(20) NOT NULL ,
 [DataInicioRelacionamento]      date NOT NULL ,
 [DataUltimaRenovacaoCadastral]  date NOT NULL ,
 [ValorBemMovel]                 decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_PatrimonioCadastroAssociadoID] PRIMARY KEY CLUSTERED ([PatrimonioCadastroAssociadoID] ASC)
);
-- ************************************** [SerasaDetalhado]
CREATE TABLE [SerasaDetalhado]
(
 [SerasaDetalhadoID] int NOT NULL ,
 [CPF_CNPJ]          varchar(20) NOT NULL ,
 [DividaVencida]     int NOT NULL ,
 [PEFIN]             int NOT NULL ,
 [Score]             int NOT NULL ,
 [AcaoJudicial]      int NOT NULL ,
 [Falencia]          int NOT NULL ,
 [Protesto]          int NOT NULL ,
 [REFIN]             int NOT NULL ,
 [Recheque]          int NOT NULL ,


 CONSTRAINT [PK_SerasaDetalhadoID] PRIMARY KEY CLUSTERED ([SerasaDetalhadoID] ASC)
);
-- ************************************** [Tarifas]
CREATE TABLE [Tarifas]
(
 [TarifasID] int NOT NULL ,
 [CPF_CNPJ]  varchar(50) NOT NULL ,
 [Tarifa]    decimal(18,2) NOT NULL ,


 CONSTRAINT [PK_TarifasID] PRIMARY KEY CLUSTERED ([TarifasID] ASC)
);
-- ************************************** [Roles]
CREATE TABLE [Roles]
(
 [RoleCode]      int NOT NULL ,
 [TipoDeUsuario] varchar(20) NOT NULL ,


 CONSTRAINT [PK_RoleCode] PRIMARY KEY CLUSTERED ([RoleCode] ASC)
);
-- ************************************** [Users]
CREATE TABLE [Users]
(
 [UsersID]       int NOT NULL ,
 [Nome]          varchar(50) NOT NULL ,
 [RoleCode]      int NOT NULL ,
 [Sobrenome]     varchar(50) NOT NULL ,
 [DataDeCriacao] date NOT NULL ,


 CONSTRAINT [PK_UsersID] PRIMARY KEY CLUSTERED ([UsersID] ASC),
 CONSTRAINT [FK_RoleCode] FOREIGN KEY ([RoleCode])  REFERENCES [Roles]([RoleCode])
);








