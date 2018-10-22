using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Request
{
    public class PersonaRequest
    {
        public int id { get; set; }
        public string nombres { get; set; }
        public string apellido_paterno { get; set; }
        public string apellido_materno { get; set; }
        public string direccion { get; set; }
        public string dni { get; set; }
        public string telefono { get; set; }
        public int? id_cargo { get; set; }

        
    }
}
