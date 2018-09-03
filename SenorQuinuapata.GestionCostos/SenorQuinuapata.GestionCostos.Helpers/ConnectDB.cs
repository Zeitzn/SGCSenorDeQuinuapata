using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.Helpers
{
    public class ConnectDB
    {
        

        public bd_sgcquinuapataEntities DBcon()
        {
            bd_sgcquinuapataEntities bd = new bd_sgcquinuapataEntities();

            return bd;
        }
    }
}
