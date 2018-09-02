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
        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamento(id);
        }

        #endregion


        #region no transaccional
        public void RegisterMovimientoDepartento(MovimientoDepartamentoRequest request)
        {
            _MovimientoDepartamentoDA.RegisterMovimientoDepartento(request);
        }

        #endregion
    }
}
