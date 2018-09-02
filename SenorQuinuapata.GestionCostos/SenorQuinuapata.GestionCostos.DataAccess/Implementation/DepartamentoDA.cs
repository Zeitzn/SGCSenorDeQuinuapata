using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class DepartamentoDA : IDepartamentoDA
    {
        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();

        //private readonly 

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
    }
}
