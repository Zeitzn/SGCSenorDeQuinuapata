using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Request
{
    public class MovimientoDepartamentoRequest
    {
       
        public DateTime? fecha { get; set; }

        [Required]
        public int? edad { get; set; }

        [Required]
        public string genero { get; set; }

        [Required]
        public int id_departamento { get; set; }

        [Required]
        public int? ingreso { get; set; }

        [Required]
        public int? salida { get; set; }

        
        public int? saldo { get; set; }

        
        public int? avance { get; set; }

        
        public int? q_equivalente { get; set; }

        
        public decimal? cu_md { get; set; }

        
        public decimal? cu_mod { get; set; }

        
        public decimal? cu_cif { get; set; }

        public decimal? cu_total { get; set; }

        public decimal? costo_total { get; set; }
    }
}
