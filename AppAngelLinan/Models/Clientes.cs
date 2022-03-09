﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AppAngelLinan.Models
{
    public partial class Clientes
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        public int? PaisId { get; set; }
        [StringLength(50)]
        public string TipoEntidad { get; set; }

        [ForeignKey(nameof(PaisId))]
        [InverseProperty(nameof(Paises.Clientes))]
        public virtual Paises Pais { get; set; }
    }
}