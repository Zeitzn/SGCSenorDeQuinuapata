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
                    
                    result = db.Database.SqlQuery<MovimientoDepartamentoResponse>("sp_movimiento_departamento_list @id_departamento",

                        new SqlParameter("@id_departamento", id)
                       

                        ).ToList();

                }
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

        public IEnumerable<MovimientoDepartamentoResponse> ListMovimientoDepartamentoReverse(int id)
        {
            try
            {
                var result = new List<MovimientoDepartamentoResponse>();
                using (db)
                {
                    result = (
                       db.Movimiento_departamento.Where(c => c.id_departamento == id).Select(x => new MovimientoDepartamentoResponse()
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

                    //   return result;


                }
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

        public MovimientoDepartamentoResponse ExistsMovimientoDepartamento(string fecha, int id_departamento,string genero)
        {
            DateTime _fecha = Convert.ToDateTime(fecha);
                //int exist = 0;
               
                Movimiento_departamento mov = new Movimiento_departamento();
                MovimientoDepartamentoResponse result = new MovimientoDepartamentoResponse();
                using (var ctx=new bd_sgcquinuapataEntities())
                {
                    mov =ctx.Movimiento_departamento.Where(x => x.fecha == _fecha && x.id_departamento == id_departamento && x.genero==genero).SingleOrDefault();

                if (mov != null)
                {
                    result.id = mov.id;
                    result.avance = mov.avance;
                    result.costo_total = mov.costo_total;
                    result.cu_cif = mov.cu_cif;
                    result.cu_md = mov.cu_md;
                    result.cu_mod = mov.cu_mod;
                    result.cu_total = mov.cu_total;
                    result.edad = mov.edad;
                    result.saldo = mov.saldo;
                    result.salida = mov.salida;
                    result.ingreso = mov.ingreso;
                    result.genero = mov.genero;
                }
                else
                {
                    result.id = 0;
                }

            

                }

                return result;
           
        }

        #endregion

        #region transaccional
        public void RegisterMovimientoDepartamento(MovimientoDepartamentoRequest request)
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

                using (var ctx=new bd_sgcquinuapataEntities())
                {
                    ctx.Movimiento_departamento.Add(movimiento);

                    ctx.SaveChanges();
                }
                
                

            }
            finally
            {
                db.Dispose();
            }
        }

        public void UpdateMovimientoDepartamento(int id,int? cantidad,int? salida)
        {
            try
            {
                using (var ctx=new bd_sgcquinuapataEntities())
                {
                    Movimiento_departamento est = ctx.Movimiento_departamento.Where(c => c.id == id).FirstOrDefault();

                    int? nueva_cantidad = est.ingreso + cantidad;

                    int? nuevo_saldo = nueva_cantidad - salida;

                    est.ingreso = nueva_cantidad;
                    est.saldo = nuevo_saldo;

                    ctx.SaveChanges();
                }
            }
            finally
            {

                //db.Dispose();
            }
        }

        public void UpdateSalidaSaldo(int origen, int? salida, int? saldo)
        {
            try
            {
               
                using (var ctx=new bd_sgcquinuapataEntities())
                {
                    
                    ctx.Database.SqlQuery<MovimientoDepartamentoResponse>("sp_salida_saldo_upd @id_movimiento_departamento, @salida, @saldo",

                        new SqlParameter("@id_movimiento_departamento", origen),
                        new SqlParameter("@salida", salida),
                        new SqlParameter("@saldo", saldo)


                        ).ToList();

                }                
            }
            finally
            {
                db.Dispose();
            }
        }

        public void RegisterNextMovimientoDepartamento(MovimientoDepartamentoRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
