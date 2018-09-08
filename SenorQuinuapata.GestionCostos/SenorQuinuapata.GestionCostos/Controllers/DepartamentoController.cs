using Ninject;
using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
//using SenorQuinuapata.GestioCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.BusinessLogic.Implementation;
using SenorQuinuapata.GestionCostos.DataAccess.DataBase;
using SenorQuinuapata.GestionCostos.Entities.Request;
using SenorQuinuapata.GestionCostos.Entities.Response;
using SenorQuinuapata.GestionCostos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SenorQuinuapata.GestionCostos.Controllers
{
    [Authorize]
    public class DepartamentoController : Controller
    {
        private readonly DepartamentoBL _DepartamentoBL=new DepartamentoBL();
        private readonly MovimientoDepartamentoBL _MovimientoDepartamentoBL = new MovimientoDepartamentoBL();
        private readonly IngresoBL _IngresoBL = new IngresoBL();

        private readonly bd_sgcquinuapataEntities db = new bd_sgcquinuapataEntities();


        // GET: Registro
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Register(MovimientoDepartamentoRequest request,string movimiento,string origen, string destino)
        {
            //try
            //{
                request.fecha = DateTime.Now;

                //request.avance = 0;
                //request.costo_total = 0;
                //request.cu_cif = 0;
                //request.cu_md = 0;
                //request.cu_mod = 0;
                //request.cu_total = 0;
                //request.edad = 0;
                //request.q_equivalente = 0;
                //request.salida = 0;
                //request.saldo = request.ingreso - request.salida;

            string fecha_actual= DateTime.Now.ToShortDateString();

            IngresoViewModel _ingreso = new IngresoViewModel();
                if (movimiento == "ingreso")
                {
                    if (origen=="Nace")
                    {
                        //request.avance = 0;
                        request.costo_total = 0;
                        request.cu_cif = 0;
                        request.cu_md = 0;
                        request.cu_mod = 0;
                        request.cu_total = 0;
                        request.edad = 0;
                        request.q_equivalente = 0;
                        request.salida = 0;
                        request.saldo = request.ingreso - request.salida;
                        request.genero = "Gazapo";
                        //request.id_departamento = 1;

                        _ingreso.Ingreso = new IngresoRequest()
                        {
                            codigo_destino = "LA001",
                            codigo_origen = "LA001",
                            lactancia = request.ingreso,
                            fecha = request.fecha,
                            genero = request.genero,

                        };

                        MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                         mov=_MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento,request.genero);

                        if (mov.id==0)
                        {
                           
                            _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                            _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);
                        }
                        else
                        {
                        //request.saldo = mov.ingreso - mov.salida;
                        request.salida = mov.salida;
                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                            _MovimientoDepartamentoBL.UpdateMovimientoDepartamento(mov.id, request.ingreso,request.salida);
                            

                        }

                       
                        
                    }

                if (origen == "1")
                {
                    if (request.id_departamento==2)
                    {
                        int _origen = Convert.ToInt32(origen);
                        int? salida = request.ingreso;
                        int? saldo, _salida,_saldo=0;
                        


                        foreach (var item in _MovimientoDepartamentoBL.ListMovimientoDepartamentoReverse(_origen))
                        {                            

                            if (item.ingreso>0)
                            {
                                if (item.saldo>=salida)
                                {

                                    saldo = item.saldo - salida;

                                    salida += item.salida;                                    

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id,salida, saldo);

                                    //ENVIO DE DATOS AL DEPARTAMENTO 2

                                    _ingreso.Ingreso = new IngresoRequest()
                                    {
                                        codigo_destino = "RE001",
                                        codigo_origen = "LA001",
                                        recria = request.ingreso,
                                        fecha = request.fecha,
                                        genero = request.genero,

                                    };

                                    MovimientoDepartamentoResponse mov = new MovimientoDepartamentoResponse();
                                    mov = _MovimientoDepartamentoBL.ExistsMovimientoDepartamento(fecha_actual, request.id_departamento, request.genero);

                                    if (mov.id == 0)
                                    {
                                        request.saldo = salida-item.salida;
                                        request.edad = 0;
                                        request.salida = 0;
                                        request.costo_total = 0;
                                        request.cu_cif = 0;
                                        request.cu_md = 0;
                                        request.cu_mod = 0;
                                        request.cu_total = 0;
                                        request.q_equivalente = 0;

                                        _MovimientoDepartamentoBL.RegisterMovimientoDepartamento(request);

                                        _IngresoBL.RegisterIngreso(_ingreso.Ingreso);
                                        
                                    }

                                    

                                    // FIN ENVIO DE DATOS AL DEPARTAMENTO 2
                                    break;
                                }
                                else
                                {
                                    salida -= item.saldo;

                                    _salida = item.salida + item.saldo;

                                    _MovimientoDepartamentoBL.UpdateSalidaSaldo(item.id,_salida,_saldo);
                                }
                            }
                        }

                    }
                }
                   
                }

               
                return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    var a = e.Message.ToString();
            //    return View("Index", request);
            //}            


         
        }


        public ActionResult Movimientos(int id)
        {
            DepartamentoViewModel movimientos = new DepartamentoViewModel()
            {
                ListMovimientoDepartamento = _MovimientoDepartamentoBL.ListMovimientoDepartamento(id)
            };

            return View(movimientos);
        }

        //PRUEBAAAA
        public ActionResult Lista()
        {

            var departamentos = new DepartamentoViewModel()
            {
                ListDepartamento = _DepartamentoBL.List()
            };

            return View(/*db.Departamento.ToList()*/departamentos);
        }
    }
}