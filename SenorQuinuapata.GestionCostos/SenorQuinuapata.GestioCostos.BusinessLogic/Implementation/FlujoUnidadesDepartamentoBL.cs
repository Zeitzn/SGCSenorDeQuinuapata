using SenorQuinuapata.GestioCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Implementation
{
    public class FlujoUnidadesDepartamentoBL : IFlujoUnidadesDepartamentoBL
    {
        private readonly FlujoUnidadesDepartamentoDA _FlujoUnidadesDepartamentoDA = new FlujoUnidadesDepartamentoDA();
        public void RegisterFlujo(FlujoUnidadesDepartamentoRequest request)
        {
            _FlujoUnidadesDepartamentoDA.RegisterFlujo(request);
        }
    }
}
