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
    public class IngresoBL : IIngresoBL
    {
        private readonly IngresoDA _IngresoDA = new IngresoDA();
        #region no transaccional
        public IEnumerable<IngresoResponse> ListIngreso()
        {
            return _IngresoDA.ListIngreso();
        }
        #endregion      

        #region no transaccional
        public void RegisterIngreso(IngresoRequest request)
        {
            _IngresoDA.RegisterIngreso(request);
        }
        #endregion

    }
}
