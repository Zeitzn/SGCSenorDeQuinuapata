using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Interface
{
    public interface IDepartamentoBL
    {
        IEnumerable<DepartamentoResponse> List();
    }
}
