using SenorQuinuapata.GestioCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Implementation
{
    public class ProductoBL : IProductoBL
    {
        private readonly ProductoDA _ProductoDA = new ProductoDA();
        public IEnumerable<ProductoResponse> List()
        {
            return _ProductoDA.List();
        }

        public void RegisterProducto(ProductoRequest producto)
        {
            _ProductoDA.RegisterProducto(producto);
        }
    }
}
