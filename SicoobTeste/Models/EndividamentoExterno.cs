﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SicoobTeste.Models
{
    public partial class EndividamentoExterno
    {
        public int EndividamentoExternoID { get; set; }
        public string CPF_CNPJ { get; set; }
        public string SubmodalidadeBacen { get; set; }
        public decimal? ValorVencerAte360Dias { get; set; }
        public decimal? ValorVencerApos360Dias { get; set; }
        public decimal? ValorVencido { get; set; }
        public decimal? Prejuizo { get; set; }
        public decimal? SaldoDevedor { get; set; }
    }
}