using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class ActivoBiologicoResponse
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public DateTime fecha_salida { get; set; }
        public string ubicacion { get; set; }
        public string genero { get; set; }
        public int numero_parto { get; set; }
        public DateTime? fecha_inicio_empadre { get; set; }
        public DateTime? fecha_fin_empadre { get; set; }
        public string raza { get; set; }
        public decimal valor_inicial { get; set; }
        public decimal tasa_depreciacion { get; set; }
        public decimal depreciacion_acumulada { get; set; }
        public decimal depreciacion_diaria { get; set; }
        public string estado { get; set; }
        public decimal valor_neto { get; set; }
        public string observacion { get; set; }
    }
}
