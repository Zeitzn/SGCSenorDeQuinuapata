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
    public class MovimientoDepartamentoDA : IMovimientoDepartamentoDA
    {
        public readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();
        #region no transaccional

        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamento(int id)
        {
            try
            {
                var result = new List<MovimientoDepartamentoResponse>();
                using (db)
                {
                    result = (
                       db.Movimiento_departamento.Where(c=>c.id_departamento==id).Select(x => new MovimientoDepartamentoResponse()
                       {
                           id = x.id,
                           avance = x.avance,
                           costo_total = x.costo_total,
                           cu_cif = x.cu_cif,
                           cu_md = x.cu_md,
                           cu_mod = x.cu_mod,
                           cu_total = x.cu_total,
                           departamento = x.Departamento.nombre,
                           edad = x.edad,
                           fecha = x.fecha,
                           genero = x.genero,
                           ingreso = x.ingreso,
                           q_equivalente = x.q_equivalente,
                           saldo = x.saldo,
                           salida = x.salida

                       })
                       
                       ).ToList();

                       return result;

                       
                }
            }
            finally
            {

            }
        }
        #endregion

        #region transaccional
        public void RegisterMovimientoDepartento(MovimientoDepartamentoRequest request)
        {
            try
            {
                Movimiento_departamento movimiento = new Movimiento_departamento()
                {
                    
                    avance = request.avance,
                    costo_total = request.costo_total,
                    cu_cif = request.cu_cif,
                    cu_md = request.cu_md,
                    cu_mod = request.cu_mod,
                    cu_total = request.cu_total,
                    edad = request.edad,
                    fecha = request.fecha,
                    genero = request.genero,
                    id_departamento = request.id_departamento,
                    ingreso = request.ingreso,
                    q_equivalente = request.q_equivalente,
                    saldo = request.saldo,
                    salida = request.salida
                };

                db.Movimiento_departamento.Add(movimiento);

                db.SaveChanges();
                

            }
            finally
            {
                db.Dispose();
            }
        }

        #endregion
    }
}
