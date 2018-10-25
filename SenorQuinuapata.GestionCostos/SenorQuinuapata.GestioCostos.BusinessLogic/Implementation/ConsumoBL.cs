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
    public class ConsumoBL : IConsumoBL
    {
        private readonly ConsumoDA _ConsumoDA = new ConsumoDA();
        public IEnumerable<ConsumoResponse> List()
        {
            return _ConsumoDA.List();
        }

        public void RegisterConsumo(ConsumoRequest consumo)
        {
            if (consumo.tipo=="mi")
            {
                consumo.mi = consumo.total;
                consumo.md = 0;
            }
            else
            {
                consumo.md = consumo.total;
                consumo.mi = 0;
            }

            _ConsumoDA.RegisterConsumo(consumo);
        }
    }
}
