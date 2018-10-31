using SenorQuinuapata.GestioCostos.BusinessLogic.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.Implementation;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestioCostos.BusinessLogic.Implementation
{
    public class RolBL : IRolBL
    {
        private readonly RolDA _RolDA = new RolDA();
        public RolResponse GetRol(string id)
        {
            return _RolDA.GetRol(id);
        }
    }
}
