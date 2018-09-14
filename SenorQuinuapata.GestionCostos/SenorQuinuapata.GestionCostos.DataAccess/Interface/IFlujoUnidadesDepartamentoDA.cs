using SenorQuinuapata.GestionCostos.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Interface
{
    public interface IFlujoUnidadesDepartamentoDA
    {
        void RegisterFlujo(FlujoUnidadesDepartamentoRequest request);
    }
}
