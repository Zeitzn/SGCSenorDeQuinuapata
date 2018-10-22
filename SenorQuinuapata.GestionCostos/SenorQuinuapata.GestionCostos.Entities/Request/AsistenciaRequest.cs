using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Request
{
    public class AsistenciaRequest
    {
        public int id { get; set; }
        public int? id_persona { get; set; }
        public DateTime? fecha { get; set; }
        public string estado { get; set; }
        public decimal? sueldo { get; set; }
    }
}
