using SenorQuinuapata.GestionCostos.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Interface
{
    public interface IFlujoUnidadesDepartamentoBL
    {
        void RegisterFlujo(FlujoUnidadesDepartamentoRequest request);
    }
}
