using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.DataAccess.Interface;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenorQuinuapata.GestionCostos.DataAccess.Implementation
{
    public class IngresoDA : IIngresoDA
    {
        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();

        #region no transaccional
        public IEnumerable<IngresoResponse> ListIngreso()
        {
            try
            {
                var result = new List<IngresoResponse>();
                using (db)
                {
                    result = (
                        db.Ingreso.Select(x => new IngresoResponse()
                        {
                            id=x.id,
                            codigo_destino = x.codigo_destino,
                            codigo_origen = x.codigo_origen,
                            descarte = x.descarte,
                            edad = x.edad,
                            engorde = x.engorde,
                            fecha = x.fecha,
                            genero = x.genero,
                            lactancia = x.lactancia,
                            mortalidad = x.mortalidad,
                            recria = x.recria
                        }).OrderByDescending(c => c.id).ToList()
                        
                        );
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
        public void RegisterIngreso(IngresoRequest request)
        {
            try
            {
                using (db)
                {
                    Ingreso ingreso = new Ingreso()
                    {
                        codigo_destino = request.codigo_destino,
                        codigo_origen = request.codigo_origen,
                        descarte = request.descarte,
                        edad = request.edad,
                        engorde = request.engorde,
                        fecha = request.fecha,
                        genero = request.genero,
                        lactancia = request.lactancia,                        
                        mortalidad = request.mortalidad,
                        recria = request.recria
                    };

                    db.Ingreso.Add(ingreso);
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
