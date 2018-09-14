using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class FlujoUnidadesDepartamentoDA : IFlujoUnidadesDepartamentoDA
    {
        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();
        public void RegisterFlujo(FlujoUnidadesDepartamentoRequest request)
        {
            try
            {
                using (db)
                {
                    if (request.id==1)
                    {
                        db.Flujo_unidades_departamento.Add(new Flujo_unidades_departamento()
                        {

                            fecha = request.fecha,
                            id_departamento = 1,
                            unidades_iniciales_proceso=request.unidades_iniciales_proceso,
                            unidades_transferidas_recria=request.unidades_transferidas_recria,
                            unidades_transferidas_mortalidad=request.unidades_transferidas_mortalidad

                        });

                    }

                    db.SaveChanges();
                }
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
