using SenorQuinuapata.GestionCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Implementation
{
    public class MovimientoDepartamentoBL : IMovimientoDepartamentoBL
    {
        private readonly MovimientoDepartamentoDA _MovimientoDepartamentoDA = new MovimientoDepartamentoDA();




        #region no transaccional
        public int ExistsMovimientoDepartamento(string fecha, int id_departamento)
        {
            return _MovimientoDepartamentoDA.ExistsMovimientoDepartamento(fecha, id_departamento);
        }
        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamento(id);
        }
               

        #endregion


        #region transaccional
        public void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request)
        {
            _MovimientoDepartamentoDA.RegisterMovimientoDepartamento(request);
        }

        public void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida)
        {
            _MovimientoDepartamentoDA.UpdateMovimientoDepartamento(id,cantidad,salida);
        }

        #endregion
    }
}
