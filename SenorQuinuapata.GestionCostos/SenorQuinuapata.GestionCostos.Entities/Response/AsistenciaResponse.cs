using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class AsistenciaResponse
    {
        public string nombre_completo { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public decimal sueldo { get; set; }
        public string descripcion { get; set; }
    }
}
