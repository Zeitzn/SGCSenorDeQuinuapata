using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Entities.Response
{
    public class IngresoResponse
    {       
        public int id { get; set; }

        public DateTime? fecha { get; set; }

        public int? edad { get; set; }

        public string genero { get; set; }

        public string codigo_origen { get; set; }

        public string codigo_destino { get; set; }

        public int? lactancia { get; set; }

        public int? recria { get; set; }

        public int? engorde { get; set; }

        public int? descarte { get; set; }

        public int? mortalidad { get; set; }
    }
}
