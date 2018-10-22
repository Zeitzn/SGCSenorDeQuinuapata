using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenorQuinuapata.GestionCostos.Models
{
    public class DepartamentoViewModel
    {
        public IEnumerable<DepartamentoResponse> ListDepartamento { get; set; }

        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento { get; set; }

        public MovimientoDepartamentoRequest RegisterMovimientoDepartamento { get; set; }

        public FlujoUnidadesDepartamentoRequest flujoUnidadesDepartamento { get; set; }
        
        public IEnumerable<ActivoBiologicoResponse> ListActivoBiologico { get; set; }
    }
}