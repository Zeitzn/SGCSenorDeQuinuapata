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

        IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id);

        void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request);

        void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida);

        MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento,string genero);

        void UpdateSalidaSaldo(int orige, int? salida, int? saldo);

        void RegisterNextMovimientoDepartamento(MovimientoDepartamentoRequest request);

        bool MakeMovimiento(MovimientoDepartamentoRequest request, IngresoRequest _ingreso, string origen);
    }
}
