using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Interface
{
    public interface IMovimientoDepartamentoBL
    {
        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id);
        void RegisterMovimientoDepartento(MovimientoDepartamentoRequest request);
    }
}
