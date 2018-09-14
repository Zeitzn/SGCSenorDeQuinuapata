using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SenorQuinuapata.GestionCostos.Models
{
    public class ProductoViewModel
    {
        public IEnumerable<ProductoResponse> ListIProducto { get; set; }

        public ProductoRequest Producto { get; set; }
    }
}