using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenorQuinuapata.GestionCostos.Models
{
    public class IngresoViewModel
    {
        public IEnumerable<IngresoResponse> ListIngreso { get; set; }

        public IngresoRequest Ingreso { get; set; }
    }
}