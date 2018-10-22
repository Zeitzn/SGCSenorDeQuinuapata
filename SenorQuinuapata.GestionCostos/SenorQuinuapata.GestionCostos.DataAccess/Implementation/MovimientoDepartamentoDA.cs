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

        public IEnumerable<ActivoBiologicoResponse> ListActivoBiologico()
        {
            try
            {
                var result = new List<ActivoBiologicoResponse>();
                using (var ctx= new bd_sgcquinuapataEntities())
                {

                    result = ctx.Database.SqlQuery<ActivoBiologicoResponse>("sp_activo_biologico_list").ToList();

                }
                return result;
            }
            finally
            {
                db.Dispose();
            }
        }

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
        public string CodeActivoBiologico()
        {

            try
            {
                string codigo = "";
                int id;
                using (var ctx = new bd_sgcquinuapataEntities())
                {
                    var result = ctx.Activo_biologico.OrderByDescending(x => x.id).FirstOrDefault();

                    if (result == null)
                    {
                        id = 0;
                    }
                    else
                    {
                        id = result.id;
                    }

                    int subcodigo = id + 1;
                    string cod_cuy; ;
                    if (subcodigo < 10)
                    {
                        cod_cuy = "AC00000";
                    }
                    else if (subcodigo >= 10 && subcodigo < 100)
                    {
                        cod_cuy = "AC0000";
                    }
                    else if (subcodigo >= 100 && subcodigo < 1000)
                    {
                        cod_cuy = "AC000";
                    }
                    else if (subcodigo >= 1000 && subcodigo < 10000)
                    {
                        cod_cuy = "AC00";
                    }
                    else if (subcodigo >= 10000 && subcodigo < 100000)
                    {
                        cod_cuy = "AC0";
                    }
                    else
                    {
                        cod_cuy = "AC";
                    }

                    codigo = cod_cuy + subcodigo;

                }

                return codigo;
            }
            catch (Exception e)
            {
                string error = e.Message;

                return error;
            }
            
        }

        #endregion

        #region transaccional

        public void UpdateDescarte(int id_movimiento, int cantidad)
        {
            try
            {
                using (var ctx = new bd_sgcquinuapataEntities())
                {
                    Movimiento_departamento _movimiento = ctx.Movimiento_departamento.Where(x => x.id == id_movimiento).FirstOrDefault();
                    int? saldo_inicial = _movimiento.saldo;
                    int? salida_inicial = _movimiento.salida;

                    _movimiento.saldo = saldo_inicial - cantidad;
                    _movimiento.salida = salida_inicial + cantidad;

                    ctx.SaveChanges();


                }
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
        }

        public void RegisterActivoBiologico(ActivoBiologicoRequest activo, string codigo)
        {
            try
            {
                using (var ctx=new bd_sgcquinuapataEntities())
                {
                    ctx.Activo_biologico.Add(
                    new Activo_biologico()
                    {
                        codigo=codigo,
                        depreciacion_acumulada=activo.depreciacion_acumulada,
                        depreciacion_diaria=activo.depreciacion_diaria,
                        estado=activo.estado,
                        fecha_fin_empadre=activo.fecha_fin_empadre,
                        fecha_ingreso=activo.fecha_ingreso,
                        fecha_inicio_empadre=activo.fecha_inicio_empadre,
                        fecha_salida=activo.fecha_salida,
                        genero=activo.genero,
                        numero_parto=activo.numero_parto,
                        observacion=activo.observacion,
                        raza=activo.raza,
                        tasa_depreciacion=activo.tasa_depreciacion,
                        ubicacion=activo.ubicacion,
                        valor_inicial=activo.valor_inicial,
                        valor_neto=activo.valor_neto
                    }    
                    );       

                    ctx.SaveChanges();
                }
            }
            catch(Exception e)
            {
                string error = e.Message;
            }
            
        }
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
        
        

        #endregion
    }
}
