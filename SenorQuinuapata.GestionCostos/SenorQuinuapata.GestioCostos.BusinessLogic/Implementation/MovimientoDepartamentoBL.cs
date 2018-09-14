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
        public MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento, string genero)
        {
            return _MovimientoDepartamentoDA.ExistsMovimientoDepartamento(fecha, id_departamento,genero);
        }
        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamento(id);
        }

        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id)
        {
            return _MovimientoDepartamentoDA.ListMovimientoDepartamentoReverse(id);
        }

        


        #endregion


        #region transaccional

        public bool MakeMovimiento(MovimientoDepartamentoRequest request, IngresoRequest _ingreso, string origen)
        {
            throw new NotImplementedException();
        }

        public void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request)
        {
            _MovimientoDepartamentoDA.RegisterMovimientoDepartamento(request);
        }

        public void RegisterNextMovimientoDepartamento(MovimientoDepartamentoRequest request)
        {
            _MovimientoDepartamentoDA.RegisterNextMovimientoDepartamento(request);
        }

        public void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida)
        {
            _MovimientoDepartamentoDA.UpdateMovimientoDepartamento(id,cantidad,salida);
        }

        public void UpdateSalidaSaldo(int origen, int? salida, int? saldo)
        {
            _MovimientoDepartamentoDA.UpdateSalidaSaldo(origen,salida,saldo);
        }

       

        #endregion
    }
}
