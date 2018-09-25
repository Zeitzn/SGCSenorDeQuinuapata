using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class DepartamentoDA : IDepartamentoDA
    {
        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();

        //private readonly 
        #region no transaccional
        public IEnumerable<DepartamentoResponse> List()
        {
            var result = new List<DepartamentoResponse>();
            try
            {              


                using (var ctx = db)
                {
                    result = (
                        db.Departamento.Select(c => new DepartamentoResponse()
                        {
                            id = c.id,
                            nombre = c.nombre
                        })

                        ).DefaultIfEmpty().ToList();
                }

                return result;
            }
            catch (NullReferenceException e)
            {
                var a=e.Message.ToString();

                return result;
            }
            finally
            {
                db.Dispose();
            }
        }
        #endregion

        public IEnumerable<FlujoUnidadesDepartamentoResponse> ListReportDemo(int id_departamento)
        {
            var result = new List<FlujoUnidadesDepartamentoResponse>();

            try
            {
                using (var ctx = db)
                {
                    if (id_departamento==1)
                    {
                        result = ctx.Database.SqlQuery<FlujoUnidadesDepartamentoResponse>("sp_flujo_unidades_departamento_lactancia_list").ToList();
                    }
                    else if (id_departamento == 2)
                    {
                        result = ctx.Database.SqlQuery<FlujoUnidadesDepartamentoResponse>("sp_flujo_unidades_departamento_recria_list").ToList();
                    }
                    else if (id_departamento == 3)
                    {
                        result = ctx.Database.SqlQuery<FlujoUnidadesDepartamentoResponse>("sp_flujo_unidades_departamento_engorde_list").ToList();
                    }
                    else
                    {
                        result = null;
                    }
                    

                }

                return result;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
