﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SicoobTeste.Models
{
    public partial class LimiteCredito
    {
        public int LimiteCreditoID { get; set; }
        public string CPF_CNPJ { get; set; }
        public decimal LimiteCreditoContrato { get; set; }
        public decimal SaldoDevedorFinal { get; set; }
        public int DiasUtilizacaoLimiteCredito { get; set; }
    }
}