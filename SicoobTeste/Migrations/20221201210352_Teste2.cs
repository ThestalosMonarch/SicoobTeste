using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SicoobTeste.Migrations
{
    public partial class Teste2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AplicacaoCota",
                columns: table => new
                {
                    AplicacaoCotaID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SaldoDiarioRDC = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoClienteContaCapitalDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AplicacaoCota", x => x.AplicacaoCotaID);
                });

            migrationBuilder.CreateTable(
                name: "Cartoes",
                columns: table => new
                {
                    CartoesID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DividaConsolidada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteAtribuido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteDisponivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteUtilizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartoes", x => x.CartoesID);
                });

            migrationBuilder.CreateTable(
                name: "CartoesTrimestre",
                columns: table => new
                {
                    CartoesTrimestreID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DividaConsolidada = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteAtribuido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteDisponivel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LimiteUtilizado = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartoesTrimestre", x => x.CartoesTrimestreID);
                });

            migrationBuilder.CreateTable(
                name: "Endividamento",
                columns: table => new
                {
                    EndividamentoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    OrigemPrejuizo = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    SubmodalidadeBacen = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: false),
                    DiasAtrasoParcela = table.Column<int>(type: "int", nullable: false),
                    SaldoDevedorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endividamento", x => x.EndividamentoID);
                });

            migrationBuilder.CreateTable(
                name: "EndividamentoExterno",
                columns: table => new
                {
                    EndividamentoExternoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    SubmodalidadeBacen = table.Column<string>(type: "text", nullable: false),
                    ValorVencerAte360Dias = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVencerApos360Dias = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorVencido = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Prejuizo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoDevedor = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndividamentoExterno", x => x.EndividamentoExternoID);
                });

            migrationBuilder.CreateTable(
                name: "EndividamentoInterno",
                columns: table => new
                {
                    EndividamentoInternoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ModalidadeProduto = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    QuantidadeParcelas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeParcelasAbertas = table.Column<int>(type: "int", nullable: false),
                    ValorContrato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoDevedorDiario = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndividamentoInterno", x => x.EndividamentoInternoID);
                });

            migrationBuilder.CreateTable(
                name: "IAP",
                columns: table => new
                {
                    IAPID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    CartaoCredito = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PacoteTarifas = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    QuantidadeProduto = table.Column<int>(type: "int", nullable: false),
                    SIPAG = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Previdencia = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CartaoDebito = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ProdutorRural = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    TituloDescontado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroVida = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroGeral = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroVidaPF_PJ = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    VidaPrestamista = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroRural = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroMassificados = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SeguroAuto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ProdutoRDC = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    PreAprovado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    LCI = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    LCA = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Investimento = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Financiamento = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Emprestimo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CreditoRural = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ContaCapital = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Servicos = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Moto = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Automovel = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Consorcio = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Cobrança = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ChequeEspecial = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    DebitoAutomaticoEfetivado = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    ContaCorrenteInativa = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SicoobNet = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    MobileBanking = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    SicoobEmpresarial = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IAP", x => x.IAPID);
                });

            migrationBuilder.CreateTable(
                name: "LimiteCredito",
                columns: table => new
                {
                    LimiteCreditoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LimiteCreditoContrato = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SaldoDevedorFinal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiasUtilizacaoLimiteCredito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LimiteCredito", x => x.LimiteCreditoID);
                });

            migrationBuilder.CreateTable(
                name: "MargemContribuicao",
                columns: table => new
                {
                    MargemContribuicaoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    ResultadoAssociados = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MargemContribuicao", x => x.MargemContribuicaoID);
                });

            migrationBuilder.CreateTable(
                name: "MediaEntradaSemestral",
                columns: table => new
                {
                    MediaEntradaSemestralID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LancamentoCredito = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntradaSemestralID", x => new { x.MediaEntradaSemestralID, x.CPF_CNPJ });
                });

            migrationBuilder.CreateTable(
                name: "MediaEntradaTrimestral",
                columns: table => new
                {
                    MediaEntradaTrimestralID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LancamentoCredito = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaEntradaTrimestral", x => x.MediaEntradaTrimestralID);
                });

            migrationBuilder.CreateTable(
                name: "PatrimonioCadastroAssociado",
                columns: table => new
                {
                    PatrimonioCadastroAssociadoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DataInicioRelacionamento = table.Column<DateTime>(type: "date", nullable: false),
                    DataUltimaRenovacaoCadastral = table.Column<DateTime>(type: "date", nullable: false),
                    ValorBemMovel = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrimonioCadastroAssociado", x => x.PatrimonioCadastroAssociadoID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleCode = table.Column<int>(type: "int", nullable: false),
                    TipoDeUsuario = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleCode", x => x.RoleCode);
                });

            migrationBuilder.CreateTable(
                name: "SerasaDetalhado",
                columns: table => new
                {
                    SerasaDetalhadoID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    DividaVencida = table.Column<int>(type: "int", nullable: false),
                    PEFIN = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AcaoJudicial = table.Column<int>(type: "int", nullable: false),
                    Falencia = table.Column<int>(type: "int", nullable: false),
                    Protesto = table.Column<int>(type: "int", nullable: false),
                    REFIN = table.Column<int>(type: "int", nullable: false),
                    Recheque = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SerasaDetalhado", x => x.SerasaDetalhadoID);
                });

            migrationBuilder.CreateTable(
                name: "Tarifas",
                columns: table => new
                {
                    TarifasID = table.Column<int>(type: "int", nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Tarifa = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifas", x => x.TarifasID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RoleCode = table.Column<int>(type: "int", nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DataDeCriacao = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UsersID);
                    table.ForeignKey(
                        name: "FK_RoleCode",
                        column: x => x.RoleCode,
                        principalTable: "Roles",
                        principalColumn: "RoleCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleCode",
                table: "Users",
                column: "RoleCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AplicacaoCota");

            migrationBuilder.DropTable(
                name: "Cartoes");

            migrationBuilder.DropTable(
                name: "CartoesTrimestre");

            migrationBuilder.DropTable(
                name: "Endividamento");

            migrationBuilder.DropTable(
                name: "EndividamentoExterno");

            migrationBuilder.DropTable(
                name: "EndividamentoInterno");

            migrationBuilder.DropTable(
                name: "IAP");

            migrationBuilder.DropTable(
                name: "LimiteCredito");

            migrationBuilder.DropTable(
                name: "MargemContribuicao");

            migrationBuilder.DropTable(
                name: "MediaEntradaSemestral");

            migrationBuilder.DropTable(
                name: "MediaEntradaTrimestral");

            migrationBuilder.DropTable(
                name: "PatrimonioCadastroAssociado");

            migrationBuilder.DropTable(
                name: "SerasaDetalhado");

            migrationBuilder.DropTable(
                name: "Tarifas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
