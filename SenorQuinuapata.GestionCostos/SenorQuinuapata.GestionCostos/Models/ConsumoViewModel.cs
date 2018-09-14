using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenorQuinuapata.GestionCostos.Models
{
    public class ConsumoViewModel
    {
        public IEnumerable<ConsumoResponse> ListConsumo { get; set; }
    }
}