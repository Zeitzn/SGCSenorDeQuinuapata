using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class ConsumoResponse
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public string codigo_producto { get; set; }
        public string nombre_producto { get; set; }
        public string codigo_departamento { get; set; }
        public decimal? md { get; set; }
        public decimal? mi { get; set; }
        public decimal? total { get; set; }
        public string tipo { get; set; }
    }
}
