using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class ConsumoDA : IConsumoDA
    {
        public readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        #region no transaccional
        public IEnumerable<ConsumoResponse> List()
        {
            try
            {
                var result = new List<ConsumoResponse>();
                using (db)
                {
                    
                    result = db.Database.SqlQuery<ConsumoResponse>("sp_consumo_list").ToList();

                }
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }


        #endregion

        #region transaccional
        public void RegisterConsumo(ConsumoRequest consumo)
        {
            try
            {
                using (db)
                {
                    db.Consumo.Add(new Consumo()
                    {
                        id=consumo.id,
                        cantidad=consumo.cantidad,
                        fecha=consumo.fecha,
                        id_departamento=consumo.id_departamento,
                        id_producto=consumo.id_producto,
                        md=consumo.md,
                        mi=consumo.mi
                    });

                    db.SaveChanges();
                }
            }
            finally
            {

                db.Dispose();
            }
        }
        #endregion
    }
}
