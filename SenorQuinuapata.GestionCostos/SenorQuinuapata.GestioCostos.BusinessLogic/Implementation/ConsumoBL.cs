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

            //consumo.fecha = DateTime.Now;

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

        public ConsumoResponse GetConsumoById(int id)
        {
            return _ConsumoDA.GetConsumoById(id);
        }


        public void UpdateConsumo(int id_consumo,decimal costo_total,string tipo)
        {

            ConsumoRequest consumo = new ConsumoRequest();

            consumo.id = id_consumo;

            if (tipo == "mi")
            {
                consumo.mi = costo_total;
                consumo.md = 0;
            }
            else
            {
                consumo.md = costo_total;
                consumo.mi = 0;
            }

            _ConsumoDA.Updateconsumo(consumo);
        }
    }
}
