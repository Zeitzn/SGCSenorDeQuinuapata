using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class MovimientoDepartamentoResponse
    {
        public int id { get; set; }

        public DateTime? fecha { get; set; }

        public int? edad { get; set; }

        public string genero { get; set; }

        public string departamento { get; set; }

        public int? ingreso { get; set; }

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
