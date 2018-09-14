using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Request
{
    public class ConsumoRequest
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public DateTime fecha { get; set; }
        public int id_producto { get; set; }
        public int id_departamento { get; set; }
        public decimal md { get; set; }
        public decimal mi { get; set; }
        public decimal total { get; set; }
        public string tipo { get; set; }
    }
}
