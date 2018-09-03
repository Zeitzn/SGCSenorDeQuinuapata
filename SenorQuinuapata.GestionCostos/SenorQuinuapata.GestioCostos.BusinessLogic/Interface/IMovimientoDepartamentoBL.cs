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
        void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request);

        void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida);

        int ExistsMovimientoDepartamento(string fecha, int id_departamento);
    }
}
