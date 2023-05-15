using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HBCR.APPMVC.Models
{
    public partial class Mascotum
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? Fecha { get; set; }
        public int? Edad { get; set; }
        public string? Color { get; set; }
        public string? Sexo { get; set; }
        public string? Especie { get; set; }
        public string? Raza { get; set; }
        public decimal? Peso { get; set; }
        public decimal? Temperatura { get; set; }
    }
}
