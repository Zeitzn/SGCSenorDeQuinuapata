using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Interface
{
    public interface IConsumoBL
    {
        IEnumerable<ConsumoResponse> List();

        void RegisterConsumo(ConsumoRequest producto);
    }
}
