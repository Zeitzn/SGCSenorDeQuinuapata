using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Interface
{
    public interface IConsumoDA
    {
        IEnumerable<ConsumoResponse> List();

        void RegisterConsumo(ConsumoRequest consumo);

        ConsumoResponse GetConsumoById(int id);

        void Updateconsumo(ConsumoRequest consumo);
    }
}
