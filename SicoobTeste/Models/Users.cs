﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SicoobTeste.Models
{
    public partial class Users
    {
        public int UsersID { get; set; }
        public string Nome { get; set; }
        public int RoleCode { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataDeCriacao { get; set; }

        public virtual Roles RoleCodeNavigation { get; set; }
    }
}