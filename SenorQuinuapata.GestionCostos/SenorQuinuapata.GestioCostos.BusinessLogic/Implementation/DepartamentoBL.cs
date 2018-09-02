using SenorQuinuapata.GestioCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.BusinessLogic.Implementation
{
    public class DepartamentoBL : IDepartamentoBL
    {
        private readonly DepartamentoDA _DepartamentoDA=new DepartamentoDA();

        

        public IEnumerable<DepartamentoResponse> List()
        {
            return _DepartamentoDA.List();
        }
    }
}
